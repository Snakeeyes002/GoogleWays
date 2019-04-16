using GW.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebUI_AuthTEST.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        //  private readonly IUnitOfWorkUserManager userManager;
        //public CustomRoleProvider(IUnitOfWorkUserManager userManager)
        // {
        //   this.userManager = userManager;
        //}
        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var userManager = DependencyResolver.Current.GetService<IUnitOfWorkUserManager>();

            LinkedList<string> roles = new LinkedList<string>();
            var user = userManager.UserService.FindBy(u => u.Email.ToUpper() == username.ToUpper()).FirstOrDefault();
            if (user != null)
            {
                foreach (var item in userManager.UserInRoleService.FindBy(x => x.UserId == user.UserId))
                {
                    roles.AddFirst(item.RoleName);
                }
            }
            return roles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            var userManager = DependencyResolver.Current.GetService<IUnitOfWorkUserManager>();

            var user = userManager.UserService.FindBy(u => u.Email.ToUpper() == username.ToUpper()).FirstOrDefault();
            if (user != null)
            {
                foreach (var item in userManager.UserInRoleService.FindBy(x => x.UserId == user.UserId))
                {
                    if (item.RoleName.ToUpper() == roleName.ToUpper())
                    {
                        outputResult = true;
                        break;
                    }
                }
            }

            return outputResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}