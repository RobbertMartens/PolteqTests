using Domain.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class Singletons
    {
        private readonly IWebDriver _driver;
        private Singletons(IWebDriver driver) { _driver = driver; }

        private static Singletons _instance;
        public static Singletons Instance(IWebDriver driver) => _instance ?? (_instance = new Singletons(driver));

        private HomePage _homePage;
        public HomePage HomePage => _homePage ?? (_homePage = new HomePage(_driver));
    }
}
