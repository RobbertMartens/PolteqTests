using Domain.Objects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pages
{
    public class AuthenticationPage : Page
    {
        // Create user
        private IWebElement _createUserEmailInput => Driver.FindElement(By.Id("email_create"));
        private IWebElement _createSubmitButton => Driver.FindElement(By.Id("SubmitCreate"));

        // Login
        private IWebElement _loginUserEmailInput => Driver.FindElement(By.Id("email"));
        private IWebElement _passwordInput => Driver.FindElement(By.Id("passwd"));
        private IWebElement _loginButton => Driver.FindElement(By.Id("SubmitLogin"));

        // Error messages
        private IWebElement _authenticationFailedMessage => Driver.FindElement(By.XPath("//* [contains(text(), 'Authentication failed')]"));


        public AuthenticationPage(IWebDriver driver) : base(driver) { }


        public void CreateUser(string email)
        {
            _createUserEmailInput.SendKeys(email);
            _createSubmitButton.Click();
        }

        public void Login(Credentials credentials)
        {
            _loginUserEmailInput.SendKeys(credentials.Username);
            _passwordInput.SendKeys(credentials.Password);
            _loginButton.Click();
        }

        public bool AuthenticationFailed()
        {
            return _authenticationFailedMessage.Displayed;
        }
    }
}
