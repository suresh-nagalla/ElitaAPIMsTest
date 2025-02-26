using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using APITestAutomation.APIutility;
using APITestAutomation.Models;

namespace APITestAutomation.Tests
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void APIInvalidLoginTest()
        {
            // Arrange
            var client = new RestClient("https://dummyjson.com");
            var request = new RestRequest("/auth/login", Method.POST);
            var loginRequest = new LoginRequest
            {
                Username = "user",
                Password = "invalidCreds"
            };
            request.AddJsonBody(loginRequest);

            // Act
            var response = client.Execute<LoginResponse>(request);

            // Assert
            Assert.AreEqual(400, (int)response.StatusCode, "Expected status code 400");
            Assert.IsNotNull(response.Data, "Response data should not be null");
            Assert.AreEqual("Username and password required", response.Data.Message, "Unexpected response message");
        }
    }
}