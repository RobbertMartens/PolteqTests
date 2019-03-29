using Domain;
using Domain.Objects;
using Domain.Pages;
using System;
using Xunit;
using Xunit.Abstractions;

namespace PolteqTests
{
    [Trait("UI tests", "Login tests")]
    public class LoginTests : IClassFixture<TestFixture>, IDisposable
    {
        private readonly ITestOutputHelper _output;
        protected readonly TestFixture _fixture;

        public LoginTests(ITestOutputHelper output, TestFixture fixture)
        {           
            _output = output;
            _fixture = fixture;
            _fixture.Driver.Manage().Cookies.DeleteAllCookies();
            _fixture.Driver.Navigate().GoToUrl(Uris.HomePageUrl);
        }

        public void Dispose()
        {
            _fixture.Driver.Manage().Cookies.DeleteAllCookies();
        }

        [Fact]
        public void Login_Succes()
        {
            _fixture.Singletons.Header.ClickLogin();
            _fixture.Singletons.AuthenticationPage.Login(_fixture.Credentials);

            Assert.True(_fixture.Singletons.Header.LoggedIn(), "Login failed!");
        }

        [Fact]
        public void Login_WrongUsername()
        {
            // Assign
            var credentials = new Credentials
            {
                Username = "Sjaakie_bonusstaakie@mailinator.com",
                Password = _fixture.Credentials.Password
            };

            // Act
            _fixture.Singletons.Header.ClickLogin();
            _fixture.Singletons.AuthenticationPage.Login(credentials);

            // Assert
            Assert.True(_fixture.Singletons.AuthenticationPage.AuthenticationFailed(), "'Auth failed message' was not displayed");
        }

        [Fact]
        public void Login_WrongPassword()
        {
            // Assign
            var credentials = new Credentials
            {
                Username = _fixture.Credentials.Username,
                Password = "sdfiojsdiofjiosdf"
            };

            // Act
            _fixture.Singletons.Header.ClickLogin();
            _fixture.Singletons.AuthenticationPage.Login(credentials);

            // Assert
            Assert.True(_fixture.Singletons.AuthenticationPage.AuthenticationFailed(), "'Auth failed message' was not displayed");
        }
    }
}
