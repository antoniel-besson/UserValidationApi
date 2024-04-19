

using System.ComponentModel;
using UserValidationApi.Factory;
using UserValidationApi.Models;

namespace UserValidationApi.Test.Factory
{
    public class UserFactoryTests
    {
        [Fact]
        public void CreateUser_Returns_AdminUser_When_Role_Is_Admin()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Username = "adminUser",
                Password = "password",
                Email = "admin@example.com",
                Role = UserTypeEnum.Admin
            };

            // Act
            var result = UserFactory.Instance.CreateUser(userRequest);

            // Assert
            Assert.IsType<AdminUser>(result);
            Assert.Equal(userRequest.Username, result.Username);
            Assert.Equal(userRequest.Password, result.Password);
            Assert.Equal(userRequest.Email, result.Email);
        }

        [Fact]
        public void CreateUser_Returns_CustomerUser_When_Role_Is_Customer()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Username = "customerUser",
                Password = "password",
                Email = "customer@example.com",
                Role = UserTypeEnum.Customer
            };

            // Act
            var result = UserFactory.Instance.CreateUser(userRequest);

            // Assert
            Assert.IsType<CustomerUser>(result);
            Assert.Equal(userRequest.Username, result.Username);
            Assert.Equal(userRequest.Password, result.Password);
            Assert.Equal(userRequest.Email, result.Email);
        }

        [Fact]
        public void CreateUser_Throws_InvalidEnumArgumentException_When_Role_Is_Invalid()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Username = "invalidUser",
                Password = "password",
                Email = "invalid@example.com",
                Role = (UserTypeEnum)99 // Invalid role
            };

            // Act & Assert
            Assert.Throws<InvalidEnumArgumentException>(() => UserFactory.Instance.CreateUser(userRequest));
        }
    }
}