using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Repositories;

namespace BL
{
    public class UserRoleBL
    {
        public int Save(UserRole userRole)
        {
            UserRoleRepository ur = new UserRoleRepository();
            if (userRole.ID > 0)
                return ur.Update(userRole);
            else return ur.Insert(userRole);            
        }

        public bool UserRoleExists(string userRole)
        {
            List<QueryParameter> queryParameters = new List<QueryParameter>();
            queryParameters.Add(new QueryParameter("name", userRole));

            return new UserRoleRepository().GetByParameter("getByName", queryParameters).Count > 0;
        }

        public string[] GetUserRolesForUsername(string username)
        {
            List<QueryParameter> queryParameters = new List<QueryParameter>();
            queryParameters.Add(new QueryParameter("username", username));

            List<UserRole> userRoles = new UserRoleRepository().GetByParameter("getUserRolesForUsername", queryParameters);

            string roles = string.Empty;
            foreach (UserRole userRole in userRoles)
                roles += userRole.Name + ",";
            return roles.Substring(0, roles.Length - 1).Split(',');
        }

        public bool IsUserInRole(string username, string userRole)
        {
            List<QueryParameter> queryParameters = new List<QueryParameter>();
            queryParameters.Add(new QueryParameter("username", username));
            queryParameters.Add(new QueryParameter("userRole", userRole));

            return new UserRoleRepository().GetByParameter("isUserInRole", queryParameters).Count > 0;
        }

        public List<UserRole> GetAllUserRoles(bool addChooseEntity)
        {
            List<UserRole> userRoles = new UserRoleRepository().GetAll();
            if (addChooseEntity)
                userRoles.Insert(0, new UserRole(-1, "Odaberi"));
            return userRoles;
        }

        public int RemoveUserFromUserRole(string username, string role)
        {
            List<QueryParameter> queryParameters = new List<QueryParameter>();
            queryParameters.Add(new QueryParameter("username", username));

            return new UserRoleRepository().ExecuteAction("userRole", "removeUserFromUserRole", queryParameters);
        }
    }
}
