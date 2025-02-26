using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using APITestAutomation.Models;
using APITestAutomation.APIutility;

namespace APITestAutomation
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void APIInvalidLoginTest()
        {
            // Arrange
            var client = new RestClient("https://dummyjson.com");
            var request = new RestRequest("/auth/login", Method.GET);
            var loginRequest = new LoginRequest
            {
                Username = "user",
                Password = "invalidCreds"
            };
            request.AddJsonBody(loginRequest);

            // Act
            var response = client.Execute<LoginResponse>(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(400, (int)response.StatusCode, "Expected status code 400");
            Assert.IsNotNull(response.Data);
            Assert.AreEqual("Username and password required", response.Data.Message);
        }
    }
}