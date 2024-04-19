using System.ComponentModel.DataAnnotations;
using UserValidationApi.Interface;
using UserValidationApi.Models;
using System.Text.RegularExpressions;
using static UserValidationApi.Factory.UserFactory;
using UserValidationApi.Factory;
using UserValidationApi.Services.Observers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UserValidationApi.Services
{
    public class UserService : SingletonManager<UserService>, IUserService
    {
        private readonly UserFactory _userFactory;

        public UserService()
        {
            _userFactory = new UserFactory();
        }

        public async Task<User> CreateUser(UserRequest user)
        {

            try
            {
                var new_user = _userFactory.CreateUser(user);
                ValidateUser(new_user);
                //create user
                return new_user;
            }
            catch (ValidationException ex)
            {                
                throw new ValidationException(ex.Message);
            }

        }



        private void ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ValidationException("Username cannot be empty.");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ValidationException("Password cannot be empty.");
            }

            if (user.Username.Length < 6)
            {
                throw new ValidationException("Username must be at least 6 characters long.");
            }

            if (user.Password.Length < 8)
            {
                throw new ValidationException("Password must be at least 8 characters long.");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ValidationException("Email cannot be empty.");
            }
            if (!IsValidEmail(user.Email))
            {
                throw new ValidationException("Invalid email format.");
            }


        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        public async Task<User> UpdateUser(User user)
        {

            var userSubject = new UserSubject();
            var userObserver = new UserObserver();
            userSubject.Attach(userObserver);

            //var user = new User("AdminUser", "AdminPassword123", "adminuser@example.com", "Admin");

            userSubject.ChangeUser(user);

            // Update user
            user.Email = "newadminuser@example.com";
            userSubject.ChangeUser(user);

            // Removendo o observador
            userSubject.Detach(userObserver);

            // Atualizando o usuário novamente (sem notificar o observador)
            user.Password = "NewPassword123";
            userSubject.ChangeUser(user);

            return user;

        }

    }
}
