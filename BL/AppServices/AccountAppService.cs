using AutoMapper;
using AutoMapper.Configuration;
using BL.Interfaces;
using BL.ViewModel;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using BL.Bases;
using Microsoft.AspNetCore.Http;
using Velites.Utility.SharedLibrary;

namespace BL.AppServices
{
    public class AccountAppService : BaseAppService
    {
        //private readonly IConfiguration _Configration;
        IConfiguration configuration;
        public AccountAppService(IConfiguration configurations)
        {
          this.configuration = configurations;
        }

        public List<UserViewModel> GetAllAccounts()
        {
            return Mapper.Map<List<UserViewModel>>(TheUnitOfWork.Account.GetAll().Where(ac => ac.isDeleted == false).ToList());
        }
        public UserViewModel GetAccountById(string id)
        {

            return Mapper.Map<UserViewModel>(TheUnitOfWork.Account.GetAccountById(id));

        }
        public bool DeleteAccount(string id)
        {
            var user = Mapper.Map<ApplicationUserIdentity>(GetAccountById(id));
            user.isDeleted = true;
            TheUnitOfWork.Account.Update(user);
            return TheUnitOfWork.Commit() > new int();
        }
        public async Task<ApplicationUserIdentity> Find(string name, string Password)
        {
            ApplicationUserIdentity user = await TheUnitOfWork.Account.Find(name, Password);
            if (user != null && user.isDeleted == false)
                return user;
            return null;
        }
        public async Task<ApplicationUserIdentity> FindByName(string userName)
        {
            ApplicationUserIdentity user = await TheUnitOfWork.Account.GetByName(userName);

            if (user != null && user.isDeleted == false)
                return user;
            return null;
        }

        private IdentityResult StatusCode(int status500InternalServerError, Response response)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> checkUserNameExist(string userName)
        {
            var user = await TheUnitOfWork.Account.GetByName(userName);
            return user == null ? false : true;
        }
        public async Task<IdentityResult> AssignRole(string userid, string rolename)
        {
            if (userid == null || rolename == null)
                return null;
            return await TheUnitOfWork.Account.AssignRole(userid, rolename);
        }
        public async Task<bool> UpdatePassword(string userID, string newPassword)
        {
            //    ApplicationUserIdentity identityUser = TheUnitOfWork.Account.FindById(user.Id);

            //    Mapper.Map(user, identityUser);

            //    return TheUnitOfWork.Account.UpdateAccount(identityUser);


            ApplicationUserIdentity identityUser = await TheUnitOfWork.Account.GetById(userID);
            identityUser.PasswordHash = newPassword;
            return await TheUnitOfWork.Account.updatePassword(identityUser);

        }
        public async Task<bool> Update(UserViewModel user)
        {

            ApplicationUserIdentity identityUser = await TheUnitOfWork.Account.GetById(user.Id);
            var oldPassword = identityUser.PasswordHash;
            Mapper.Map(user, identityUser);
            identityUser.PasswordHash = oldPassword;
            return await TheUnitOfWork.Account.UpdateAccount(identityUser);

        }
        public async Task<IEnumerable<string>> GetUserRoles(ApplicationUserIdentity user)
        {
            return await TheUnitOfWork.Account.GetUserRoles(user);
        }
        public async Task<dynamic> CreateToken(ApplicationUserIdentity user)
        {
            var userRoles = await GetUserRoles(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim("role",userRoles.FirstOrDefault()),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(

                audience: configuration["JWT:ValidAudience"],
                 issuer: configuration["JWT:ValidIssuer"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };


        }
        public int CountEntity()
        {
            return TheUnitOfWork.Account.CountEntity();
        }
        public async Task<IdentityResult> Register(UserViewModel user)
        {
            bool isExist = await checkUserNameExist(user.UserName);
            if (isExist)
                return IdentityResult.Failed(new IdentityError
                { Code = "error", Description = "user name already exist" });

            ApplicationUserIdentity identityUser = Mapper.Map<UserViewModel, ApplicationUserIdentity>(user);
            var result = await TheUnitOfWork.Account.Register(identityUser);
            return result;
        }
    }
}