using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Security
{
    public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

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

        public override string[] GetRolesForUser(string email)
        {
            Model1 m = new Model1();
            var user = m.User_.FirstOrDefault(x => x.email == email);

            // Return the user's role information.
            List<UserRole> role_records = m.UserRole.Where(x => x.id_user == user.id).ToList();
            List<Role_> user_role_records = new List<Role_>();

            string[] roles = new string[role_records.Count];

            for (int counter = 0; counter < role_records.Count; ++ counter)
            {
                int temp_role_id = role_records[counter].id_role;
                roles[counter] = m.Role_.FirstOrDefault(x => x.id == temp_role_id).role_name;
            }

            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
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