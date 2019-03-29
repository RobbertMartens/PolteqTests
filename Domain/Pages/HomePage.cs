using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pages
{
    public class HomePage : Page
    {
        private IWebElement _loginButton => Driver.FindElement(By.XPath("//* [@class='login']"));

        public HomePage(IWebDriver driver) : base(driver) { }

        public void ClickLogin()
        {
            _loginButton.Click();
        }
    }
}
