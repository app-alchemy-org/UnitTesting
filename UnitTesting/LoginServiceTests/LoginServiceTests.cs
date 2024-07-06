using BudgetTracking.Services;
using LoginServiceExample.Enums;
using LoginServiceExample.Interfaces;
using LoginServiceExample.Models;
using Moq;
using System.Net;

namespace LoginServiceTests
{
    public class LoginServiceTests
    {
        [Fact]
        public async void ServerNotAvailableTest()
        {
            //Arrange
            var webClientMock = new Mock<IWebClient>();
            var secureStorageMock = new Mock<ISecureStorage>();

            const string email = "email";
            const string password = "password";

            const string sessionToken = "1234";
            var expiryDate = DateTime.Now;

            webClientMock.Setup(x => x.Login(email, password))
                .Returns(Task.FromResult(new WebLoginResponse(HttpStatusCode.ServiceUnavailable, sessionToken, expiryDate)));

            var loginService = new LoginService(webClientMock.Object, secureStorageMock.Object);

            //Act
            var loginResponse = await loginService.Login(email, password);

            //Assert
            Assert.Equal(LoginResponseType.ServerNotAvailable, loginResponse);
        }

        [Fact]
        public async void SuccessTest()
        {
            //Arrange
            var webClientMock = new Mock<IWebClient>();
            var secureStorageMock = new Mock<ISecureStorage>();

            const string email = "email";
            const string password = "password";

            const string sessionToken = "1234";
            var expiryDate = DateTime.Now;

            webClientMock.Setup(x => x.Login(email, password))
                .Returns(Task.FromResult(new WebLoginResponse(HttpStatusCode.OK, sessionToken, expiryDate)));

            secureStorageMock.Setup(x => x.SetSecureLogin(email, expiryDate, sessionToken)).Returns(true);

            var loginService = new LoginService(webClientMock.Object, secureStorageMock.Object);

            //Act
            var loginResponse = await loginService.Login(email, password);

            //Assert
            Assert.Equal(LoginResponseType.Success, loginResponse);
        }

        [Fact]
        public void AutoLoginTest()
        {
            //Arrange
            var webClientMock = new Mock<IWebClient>();
            var secureStorageMock = new Mock<ISecureStorage>();

            const string email = "email";

            const string sessionToken = "1234";
            var expiryDate = DateTime.Now.AddDays(10);

            secureStorageMock.Setup(x => x.GetSecureLogin()).Returns(new SecureLogin(email, expiryDate, sessionToken));

            var loginService = new LoginService(webClientMock.Object, secureStorageMock.Object);

            //Act
            var loginResponse = loginService.AutoLogin();

            //Assert
            Assert.True(loginResponse);
        }
    }
}