using Domain;
using Domain.Objects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace PolteqTests
{
    [Collection("SingleThreading")]
    [Trait("UI tests", "Login tests")]
    public class LoginTests : IClassFixture<TestFixture>, IDisposable
    {
        private readonly ITestOutputHelper _output;
        protected readonly TestFixture _fixture;

        public LoginTests(ITestOutputHelper output, TestFixture fixture)
        {           
            _output = output;
            _fixture = fixture;
            _fixture.Driver.Navigate().GoToUrl(Constants.HomePageUrl);
        }

        public virtual void Dispose()
        {
            _fixture.Driver.Manage().Cookies.DeleteAllCookies();
            _fixture.Driver.Navigate().GoToUrl(Constants.HomePageUrl);
        }

        [Fact]
        public void Login_Succes()
        {
            _fixture.Singletons.Header.ClickLogin();
            _fixture.Singletons.AuthenticationPage.Login(_fixture.Credentials);

            Assert.True(_fixture.Singletons.Header.LoginSucceeded(), "Login failed, while it should succeed!");
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
            Assert.False(_fixture.Singletons.Header.LoginSucceeded(), "Login succeeded while it should have failed");
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
            Assert.False(_fixture.Singletons.Header.LoginSucceeded(), "'Login succeeded while it should have failed");
        }
    }
}
