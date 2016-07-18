using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BE;

namespace BL
{
    public class CustomMembershipProvider:MembershipProvider
    {
        private string _firstName;
        private string _lastName;
        private UserRole _userRole;
        /*private EduEntity _department;
        private UserStatus _userStatus;
        private string _areaOfInterest;*/

        /*private string _address;*/
        /*private string _city;*/
        /*private string _phone;*/
        /*private string _userType;*/
        

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public UserRole UserRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }

        /*public EduEntity Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public UserStatus UserStatus
        {
            get { return _userStatus; }
            set { _userStatus = value; }
        }

        public string AreaOfInterest
        {
            get { return _areaOfInterest; }
            set { _areaOfInterest = value; }
        }*/

        /*public string Address
        {
            get { return _address; }
            set { _address = value; }
        }*/

        /*public string City
        {
            get { return _city; }
            set { _city = value; }
        }*/

        /*public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }*/

        /*public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }*/

        public CustomMembershipProvider()
        {
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        public override bool ValidateUser(string username, string password)
        {
            UserBL userBL = new UserBL();
            string salt = userBL.GetSalt(username);
            if (salt != null && salt != string.Empty)
            {
                password = userBL.hashPassword(password, salt);
                return userBL.ValidateUser(username, password);
            }
            return false;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return NewUser(username, password, email, FirstName, LastName, UserRole, isApproved, out status);
        }

        public MembershipUser NewUser(string username, string password, string email, string firstName, string lastName, UserRole userRole, bool isApproved, out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != "")
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            //status = MembershipCreateStatus.InvalidAnswer;
            MembershipUser user = GetUser(email, false);
            if (user == null)
            {
                UserBL userBL = new UserBL();
                string salt = userBL.getSalt();
                password = userBL.hashPassword(password, salt);
                if (userBL.Save(FirstName, LastName, username, password, email, UserRole.ID, salt, 0) > 0)
                    status = MembershipCreateStatus.Success;
                else
                    status = MembershipCreateStatus.UserRejected;
            }
            else
                status = MembershipCreateStatus.DuplicateUserName;

            return null;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser user = null;

            UserBL userBL = new UserBL();
            User userTable = userBL.GetUserByUsername(username);
            if (userTable!=null)
            {
                user = new MembershipUser("CustomMembershipProvider", username, userTable.ID, string.Empty, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            }

            return user;
        }

        public override string GetUserNameByEmail(string email)
        {
            string username = string.Empty;

            UserBL userBL = new UserBL();
            User userTable = userBL.GetUser(email);
            if (userTable != null)
                username = userTable.Username;

            return username;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 3; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 1; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 5; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
