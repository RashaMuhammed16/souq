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

namespace BL.AppServices
{
    class AccountAppService:Bases.AppServiceBase
    {
      IConfiguration configuration;
        AccountAppService(IConfiguration configurations,IUnitOfWork iunitOfWork,IMapper mapper,IConfiguration configuration):base(iunitOfWork,mapper)
        {
            this.configuration = configurations;
        }
        public List<UserViewModel> GetAllAccounts()
        {
            return Mapper.Map<List<UserViewModel>>(TheUnitOfWork.account.GetAll().Where(ac=>ac.isDeleted==false).ToList());
        }
        public UserViewModel GetAccountById(string id)
        {

            return Mapper.Map<UserViewModel>(TheUnitOfWork.account.GetAccountById(id));

        }
        public bool DeleteAccount(string id)
        {
           var user= Mapper.Map<ApplicationUserIdentity>( GetAccountById(id));
            user.isDeleted = true;
            TheUnitOfWork.account.Update(user);
            return TheUnitOfWork.Commit() > new int();
        }
        public async Task<ApplicationUserIdentity>Find(string name,string Password)
        {
            ApplicationUserIdentity user =await TheUnitOfWork.account.Find(name, Password);
            if (user != null && user.isDeleted == false)
                return user;
            return null;
        }
        public async Task<ApplicationUserIdentity> FindByName(string userName)
        {
            ApplicationUserIdentity user = await TheUnitOfWork.account.GetByName(userName);

            if (user != null && user.isDeleted == false)
                return user;
            return null;
        }
        public async Task<IdentityResult> Register(UserViewModel user)
        {
            bool isExist = await checkUserNameExist(user.UserName);
            if (isExist)
                return IdentityResult.Failed(new IdentityError
                { Code = "error", Description = "user name already exist" });

            ApplicationUserIdentity identityUser = Mapper.Map<UserViewModel, ApplicationUserIdentity>(user);
            var result = await TheUnitOfWork.account.Register(identityUser);
            // create user cart and wishlist 
            if (result.Succeeded)
            {
                //CreateUserCartAndWishlist(identityUser.Id);
            }
            return result;
        }
        public async Task<bool> checkUserNameExist(string userName)
        {
            var user = await TheUnitOfWork.account.GetByName(userName);
            return user == null ? false : true;
        }
        public async Task<IdentityResult> AssignRole(string userid, string rolename)
        {
            if (userid == null || rolename == null)
                return null;
            return await TheUnitOfWork.account.AssignRole(userid, rolename);
        }
        public async Task<bool> UpdatePassword(string userID, string newPassword)
        {
            //    ApplicationUserIdentity identityUser = TheUnitOfWork.Account.FindById(user.Id);

            //    Mapper.Map(user, identityUser);

            //    return TheUnitOfWork.Account.UpdateAccount(identityUser);


            ApplicationUserIdentity identityUser = await TheUnitOfWork.account.GetById(userID);
            identityUser.PasswordHash = newPassword;
            return await TheUnitOfWork.account.updatePassword(identityUser);

        }
        public async Task<bool> Update(UserViewModel user)
        {

            ApplicationUserIdentity identityUser = await TheUnitOfWork.account.GetById(user.Id);
            var oldPassword = identityUser.PasswordHash;
            Mapper.Map(user, identityUser);
            identityUser.PasswordHash = oldPassword;
            return await TheUnitOfWork.account.UpdateAccount(identityUser);

        }
        public async Task<IEnumerable<string>> GetUserRoles(ApplicationUserIdentity user)
        {
            return await TheUnitOfWork.account.GetUserRoles(user);
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
            return TheUnitOfWork.account.CountEntity();
        }

    }
}
