using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MVCWordDictionary.Models;
using System.Configuration;
using System.Data.Entity.Core.Objects;

namespace MVCWordDictionary.Authorization
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private WordManagerEntities _db;
        private string _passwordSalt = ConfigurationManager.AppSettings["PasswordSalt"];

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

        public CustomMembershipProvider()
        {
            _db = new WordManagerEntities();
        }
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var user = _db.aspnet_Users.Where(x => x.UserName == username).FirstOrDefault();
            if (user != null)
            {
                var membership = user.aspnet_Membership;
                membership.Password = Common.GenerateHashWithSalt(newPassword, _passwordSalt);
            return _db.SaveChanges() > 0;
            }
            return false;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            string pass = Common.GenerateHashWithSalt(password, _passwordSalt);
            ObjectParameter param = new ObjectParameter("userID", DBNull.Value);
            ObjectResult<Guid?> userid = _db.aspnet_Membership_CreateUser("MVCWordDictionary", username, pass, _passwordSalt, "", "", "", true, DateTime.Now, DateTime.Now, 0, 6, param);

            if (userid != null)
            {
                status = MembershipCreateStatus.Success;
            }
            else
            {
                status = MembershipCreateStatus.UserRejected;
            }

            return new MembershipUser("CustomMembershipProvider", username, userid, email, passwordQuestion, "", true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
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
            var user = _db.aspnet_Users.Where(x => x.UserName == username).FirstOrDefault();

            if (user != null)
            {
                return user.aspnet_Membership.Password;
            }
            return null;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = _db.aspnet_Users.Where(x => x.UserName == username).FirstOrDefault();

            if (user != null)
            {
                var membership = user.aspnet_Membership;
                return new MembershipUser("CustomMembershipProvider", user.UserName, user.UserId, membership.Email, membership.PasswordQuestion, "", true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            }
            return null;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
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

        public override bool ValidateUser(string username, string password)
        {
            var user = _db.aspnet_Users.Where(x => x.UserName == username).FirstOrDefault();
            if (user == null)
            {
                return false;
            }

            if (user.aspnet_Membership.Password == Common.GenerateHashWithSalt(password, _passwordSalt))
            {
                return true;
            }

            return false;
        }
    }
}