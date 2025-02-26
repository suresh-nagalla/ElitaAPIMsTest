using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using APITestAutomation.Models;
using System.Threading.Tasks;

namespace APITestAutomation
{
    [TestClass]
    public class APITests
    {
        private const string BaseUrl = "https://dummyjson.com";

        [TestMethod]
        public async Task APIInvalidLoginTest()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/auth/login", Method.GET);
            var loginRequest = new LoginRequest
            {
                Username = "user",
                Password = "invalidCreds"
            };
            request.AddJsonBody(loginRequest);

            // Act
            var response = await client.ExecuteAsync<LoginResponse>(request);

            // Assert
            Assert.IsNotNull(response, "Response should not be null");
            Assert.IsTrue(response.IsSuccessful, "Response should be successful");
            Assert.AreEqual("Username and password required", response.Data.Message, "The response message did not match the expected value.");
        }
    }
}