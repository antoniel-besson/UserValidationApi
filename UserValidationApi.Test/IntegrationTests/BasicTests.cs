using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserValidationApi.Models;

namespace UserValidationApi.Test.IntegrationTests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BasicTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/User/CreateUser")]
        public async Task CreateUser_EndpointReturnsSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            var userRequest = new UserRequest
            {                
                Username = "testUser",
                Password = "TestPassword123",
                Email = "test@example.com",                
            };

            var jsonContent = JsonConvert.SerializeObject(userRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url))
            {
                requestMessage.Content = content;

                var response = await client.SendAsync(requestMessage);

                // Assert
                response.EnsureSuccessStatusCode(); // Status Code 200-299
                Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            }
        }
    }


}
