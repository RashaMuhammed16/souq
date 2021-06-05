using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bases;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BL.Repositories
{
   public class AccountRepository:BaseRepository<ApplicationUserIdentity>
    {
        private DbContext EC_DbContext;
        private readonly UserManager<ApplicationUserIdentity> manger;
        private RoleManager<IdentityRole> role;
        //public AccountRepository(DbContext context,UserManager<ApplicationUserIdentity>usermanger,RoleManager<IdentityRole>role):base(context)
        //  {
        //      this.role = role;
        //      this.manger = usermanger;
        //      this.EC_DbContext = EC_DbContext;

        //  }
        public AccountRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public ApplicationUserIdentity GetAccountById(string id)
        {
           
            return GetFirstOrDefault(acc => acc.Id == id);
        }
       public List<ApplicationUserIdentity> GetAll()
        {
            return GetAll().ToList();
        }
        public async Task<ApplicationUserIdentity>GetByName(string UserName)
        {
            var result = await manger.FindByNameAsync(UserName);
            
            return result;
        }
        public async Task<ApplicationUserIdentity> GetById(string id)
        {
            var result = await manger.FindByIdAsync(id);

            return result;
        }
        public async Task<ApplicationUserIdentity>Find(string UserName,string Password)

        {
            ApplicationUserIdentity user =await GetByName(UserName);
            if (user != null && await manger.CheckPasswordAsync( user, Password))
                return  user;
            return null;
        }
        public async Task<IdentityResult>Register(ApplicationUserIdentity user)
        {
            user.Id = Guid.NewGuid().ToString();
            var result = await manger.CreateAsync(user);
            return result;
        }
        public async Task<IdentityResult> AssignRole(string userName, string roleName)
        {
            var user = await GetByName(userName);
            IdentityResult res;
            if (user != null && await role.RoleExistsAsync(roleName))
            {
                res = await manger.AddToRoleAsync(user, roleName);
                return res;
            }
            return null;
        }
        public async Task<bool> updatePassword(ApplicationUserIdentity user)
        {
            manger.PasswordHasher.HashPassword(user, user.PasswordHash);
            //user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
            IdentityResult result = await manger.UpdateAsync(user);
            return true;
        }
        public async Task<IEnumerable<string>> GetUserRoles(ApplicationUserIdentity user)
        {
            var userRoles = await manger.GetRolesAsync(user);
            return userRoles;
        }
        public async Task<bool> UpdateAccount(ApplicationUserIdentity user)
        {

            //user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
            //try
            //{

            //    IdentityResult result = manager.Update(user);
            //}
            //catch (Exception e)
            //{


            //}
            IdentityResult result = await manger.UpdateAsync(user);

            return true;
        }
    }
   

}
