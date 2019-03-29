using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pages
{
    public class Page
    {
        protected IWebDriver Driver { get; private set; }

        public Page(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
