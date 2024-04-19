using System.ComponentModel;
using System.Data;
using UserValidationApi.Models;
using UserValidationApi.Services;

namespace UserValidationApi.Factory
{
    public class UserFactory : SingletonManager<UserFactory>
    {
        public User CreateUser(UserRequest user)
        {
            switch (user.Role)
            {
                case UserTypeEnum.Admin:
                    return new AdminUser
                    {
                        Username = user.Username,
                        Password = user.Password,
                        Email = user.Email
                    };

                case UserTypeEnum.Customer:
                    return new CustomerUser
                    {
                        Username = user.Username,
                        Password = user.Password,
                        Email = user.Email
                    };

                default:
                    throw new InvalidEnumArgumentException("Invalid user type");
            }
        }
    }

}
