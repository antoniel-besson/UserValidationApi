
using System;
using Xunit;
using UserValidationApi.Models;
using UserValidationApi.Services;
using System.ComponentModel.DataAnnotations;
using UserValidationApi.Factory;

namespace UserValidationApi.Test.Services
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly UserFactory _userFactory;
        private readonly User _userTest;

        public UserServiceTests()
        {
            _userService = new UserService();
            _userFactory = new UserFactory();
        }

  
        [Fact]
        public async void CreateUser_ValidUser_ReturnsUser()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Username = "TestUser",
                Password = "TestPassword123",
                Email = "testuser@example.com"
            };

            // Act
            var result = await _userService.CreateUser(userRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userRequest.Username, result.Username);
            Assert.Equal(userRequest.Password, result.Password);
            Assert.Equal(userRequest.Email, result.Email);
        }

        [Theory]
        [InlineData("", "TestPassword123", "testuser@example.com", "Username cannot be empty.")]
        [InlineData("TestUser", "", "testuser@example.com", "Password cannot be empty.")]
        [InlineData("Test", "TestPass", "testuser@example", "Username must be at least 6 characters long.")]
        [InlineData("TestUser", "Test", "testuser@example", "Password must be at least 8 characters long.")]
        [InlineData("TestUser", "TestPassword123", "", "Email cannot be empty.")]
        [InlineData("TestUser", "TestPassword123", "testuser@example", "Invalid email format.")]
        public async void CreateUser_InvalidUser_ThrowsValidationException(string username, string password, string email, string errorMessage)
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Username = username,
                Password = password,
                Email = email
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _userService.CreateUser(userRequest));
            Assert.Equal(errorMessage, exception.Message);
        }

        [Fact]
        public async void UpdateUser_ValidUser_ReturnsUpdatedUser()
        {
            // Arrange
            var user = new User
            {
                Username = "TestUser",
                Password = "TestPassword123",
                Email = "testuser@example.com"
            };

            // Act
            var result = await _userService.UpdateUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("newadminuser@example.com", result.Email);
            Assert.Equal("NewPassword123", result.Password);
        }
    }
}
