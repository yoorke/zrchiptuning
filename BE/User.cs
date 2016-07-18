using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User : BaseEntity
    {
        [SqlFieldNameAttribute("lastname")]
        public string LastName { get; set; }

        [SqlFieldNameAttribute("firstname")]
        public string FirstName { get; set; }

        [SqlFieldNameAttribute("email")]
        public string Email { get; set; }

        //[SqlFieldNameAttribute("isActive")]
        //public bool isActive { get; set; }

        [SqlFieldNameAttribute("username")]
        public string Username { get; set; }

        [SqlFieldNameAttribute("password")]
        public string Password { get; set; }

        [SqlFieldNameAttribute("salt")]
        public string Salt { get; set; }

        [SqlFieldNameAttribute("userRoleID", "UserRole", "id", Relation.OneToOne)]
        public UserRole UserRole { get; set; }

        [SqlFieldNameAttribute("imageUrl")]
        public string ImageUrl { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public User()
        {

        }

        public User(int id, string lastName, string firstName, string email, bool active, string username, string password, string salt, UserRole userRole, string imageUrl)
        {
            this.ID = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Email = email;
            this._isActive = active;
            this.Username = username;
            this.Password = password;
            this.Salt = salt;
            this.UserRole = UserRole;
            this.ImageUrl = imageUrl;
        }
    }
}
