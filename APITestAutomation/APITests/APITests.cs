using Microsoft.VisualStudio.TestTools.UnitTesting;
using APITestAutomation.APIutility;
using APITestAutomation.Models;
using System.Net;

namespace APITestAutomation.APITests
{
    [TestClass]
    public class APITests
    {
        private const string BaseUrl = "https://dummyjson.com";
        private const string LoginEndpoint = "/auth/login";

        [TestMethod]
        public void API_InvalidLogin_ShouldReturnErrorMessage()
        {
            // Arrange
            var apiUtility = new APIUtility(BaseUrl);
            var loginRequest = new LoginRequest
            {
                Username = "user",
                Password = "invalidCreds"
            };

            // Act
            var response = apiUtility.Post<LoginResponse, LoginRequest>(LoginEndpoint, loginRequest);

            // Assert
            Assert.IsNotNull(response, "Response should not be null");
            Assert.AreEqual("Username and password required", response.Message, "The error message is not as expected.");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "The status code is not as expected.");
        }
    }
}