using Xunit;
using Microsoft.AspNetCore.Mvc;
using UserValidationApi.Controllers;
using UserValidationApi.Interface;
using UserValidationApi.Models;
using System.ComponentModel.DataAnnotations;
using Moq;
using System.Threading.Tasks;
using Castle.Core.Resource;

namespace UserValidationApi.Test.Controlers
{
    public class UserControllerTests
    {
        private readonly UserController _userController;
        private readonly Mock<IUserService> _mockUserService;

        public UserControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _userController = new UserController(_mockUserService.Object);
        }

        [Fact]
        public async Task CreateUser_ValidUser_ReturnsOkResult()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Username = "TestUser",
                Password = "TestPassword123",
                Email = "testuser@example.com"
            };

            var mockUser = new User
            {
                Username = "TestUser",
                Password = "TestPassword123",
                Email = "testuser@example.com"
            };

            _mockUserService.Setup(service => service.CreateUser(userRequest)).ReturnsAsync(mockUser);

            // Act
            var result = await _userController.CreateUser(userRequest);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(mockUser, okResult.Value);
        }

        [Fact]
        public async Task CreateUser_ValidUserCustomer_ReturnsOkResult()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Username = "TestUser",
                Password = "TestPassword123",
                Email = "testuser@example.com",
                Role = UserTypeEnum.Customer
                
            };

            var mockUser = new User
            {
                Username = "TestUser",
                Password = "TestPassword123",
                Email = "testuser@example.com",
                Role = "Customer"
            };

            _mockUserService.Setup(service => service.CreateUser(userRequest)).ReturnsAsync(mockUser);

            // Act
            var result = await _userController.CreateUser(userRequest);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(mockUser, okResult.Value);
        }

        [Theory]
        [InlineData("", "TestPassword123", "testuser@example.com")]
        [InlineData("TestUser", "", "testuser@example.com")]
        [InlineData("Test", "TestPass", "testuser@example")]
        [InlineData("TestUser", "Test", "testuser@example")]
        [InlineData("TestUser", "TestPassword123", "")]
        [InlineData("TestUser", "TestPassword123", "testuser@example")]
        public async Task CreateUser_InvalidUser_ReturnsBadRequest(string username, string password, string email)
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Username = username,
                Password = password,
                Email = email
            };

            _mockUserService.Setup(service => service.CreateUser(userRequest)).ThrowsAsync(new ValidationException("Validation Error"));

            // Act
            var result = await _userController.CreateUser(userRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.NotNull(badRequestResult);
            Assert.Equal("Validation Error", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateUser_ValidUser_ReturnsOkResult()
        {
            // Arrange
            var user = new User
            {
                Username = "TestUser",
                Password = "TestPassword123",
                Email = "testuser@example.com"
            };

            var mockUpdatedUser = new User
            {
                Username = "TestUser",
                Password = "NewPassword123",
                Email = "newadminuser@example.com"
            };

            _mockUserService.Setup(service => service.UpdateUser(user)).ReturnsAsync(mockUpdatedUser);

            // Act
            var result = await _userController.UpdateUser(user);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(mockUpdatedUser, okResult.Value);
        }
    }
}