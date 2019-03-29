using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pages
{
    public class Header : Page
    {
        // Account menu
        private IWebElement _loginButton => Driver.FindElement(By.XPath("//* [@class='login']"));
        private IWebElement _logoutButton => Driver.FindElement(By.XPath("//* [@class='logout']"));
        private IWebElement _myAccountButton => Driver.FindElement(By.XPath("//* [@class='account']"));

        // Nav bar
        private IWebElement _homeButton => Driver.FindElement(By.XPath("//* [@title='TestShop']"));
        private IWebElement _ipodsButton => Driver.FindElement(By.XPath("//* [@title='iPods']"));
        private IWebElement _accessoriesButton => Driver.FindElement(By.XPath("//* [@title='Accessories']"));

        // Search bar
        private IWebElement _searchInput => Driver.FindElement(By.Id("search_query_top"));
        private IWebElement _searchButton => Driver.FindElement(By.XPath("//* [@name='submit_search']"));


        public Header(IWebDriver driver) : base (driver) {}


        public void ClickLogin()
        {
            _loginButton.Click();
        }

        public bool LoggedIn()
        {
            return _logoutButton.Displayed;
        }
    }
}
