using Microsoft.VisualStudio.TestTools.UnitTesting;
using APITestAutomation.APIutility;
using APITestAutomation.Models;
using RestSharp;

namespace APITestAutomation
{
    [TestClass]
    public class APITests
    {
        private const string BaseUrl = "https://dummyjson.com";

        [TestMethod]
        public void APIInvalidLoginTest()
        {
            // Arrange
            var apiUtility = new APIUtility(BaseUrl);
            var loginRequest = new LoginRequest
            {
                Username = "user",
                Password = "invalidCreds"
            };

            // Act
            var response = apiUtility.Post<LoginResponse, LoginRequest>("/auth/login", loginRequest);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual("Username and password required", response.Message);
        }
    }
}