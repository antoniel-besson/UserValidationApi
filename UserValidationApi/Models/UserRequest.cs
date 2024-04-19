using System;
using UserValidationApi.Extension;

namespace UserValidationApi.Models
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        //public string Role { get; set; }

        private UserTypeEnum? _role;
        public UserTypeEnum? Role
        {
            get { return _role == null ? UserTypeEnum.Admin : _role; }

            set { _role = value?.ToString().ToEnum<UserTypeEnum>(); }
        }




    }

}
