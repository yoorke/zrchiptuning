using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using BE;
using System.Security.Cryptography;

namespace BL
{
    public class UserBL
    {
        public int Save(User user)
        {
            UserRepository ur = new UserRepository();
            if (user.ID > 0)
                return ur.Update(user);
            else
                return ur.Insert(user);
        }

        public User GetUser(int id)
        {
            UserRepository ur = new UserRepository();
            return ur.GetByID(id);
        }

        public User GetUser(string email)
        {
            List<QueryParameter> queryParameters = new List<QueryParameter>();
            queryParameters.Add(new QueryParameter("email", email));

            return new UserRepository().GetByParameter("getByEmail", queryParameters)[0];
        }

        public List<User> GetAllUsers(bool addSelect)
        {
            return (addSelect) ? GetEmpty(new UserRepository().GetAll()) : new UserRepository().GetAll();
        }

        public User GetUserByUsername(string username)
        {
            List<QueryParameter> queryParameters = new List<QueryParameter>();
            queryParameters.Add(new QueryParameter("username", username));

            List<User> users = new UserRepository().GetByParameter("getByUsername", queryParameters);
            return users != null ? users[0] : null;
        }

        public int Save(string firstName, string lastName, string username, string password, string email, int userRoleID, string salt, int userID)
        {
            User user = new User();
            user._isActive = true;
            user.LastName = lastName;
            user.FirstName = firstName;
            user.Email = email;
            user.Username = username;
            user.Salt = getSalt();
            user.Password = hashPassword(password, user.Salt);
            user.UserRole = new UserRole(userRoleID, string.Empty);
            user.ID = userID;
            user.ImageUrl = string.Empty;

            return Save(user);
        }

        public string hashPassword(string password, string salt)
        {
            System.Text.UnicodeEncoding ue = new UnicodeEncoding();
            byte[] uePassword = ue.GetBytes(password);
            byte[] retVal = null;

            HMACSHA1 SHA1KeyedHasher = new HMACSHA1();
            SHA1KeyedHasher.Key = ue.GetBytes(salt);
            retVal = SHA1KeyedHasher.ComputeHash(uePassword);

            return Convert.ToBase64String(retVal);
        }

        public string getSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] random = new byte[32];
            rng.GetBytes(random);

            return Convert.ToBase64String(random);
        }

        public string GetSalt(string username)
        {
            User user = GetUserByUsername(username);
            return user != null ? user.Salt : string.Empty;
        }

        public bool ValidateUser(string username, string password)
        {
            List<QueryParameter> queryParameters = new List<QueryParameter>();
            queryParameters.Add(new QueryParameter("username", username));
            queryParameters.Add(new QueryParameter("password", password));
            List<User> users = new UserRepository().GetByParameter("validateUser", queryParameters);
            return users != null ? true : false;
        }

        private List<User> GetEmpty(List<User> users)
        {
            users.Insert(0, new User(-1, "==Odaberi==", string.Empty, string.Empty, false, string.Empty, string.Empty, string.Empty, null, string.Empty));
            return users;
        }
    }
}
