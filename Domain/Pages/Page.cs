using Domain.Helpers;
using OpenQA.Selenium;

namespace Domain.Pages
{
    public class Page
    {
        protected IWebDriver Driver { get; private set; }
        protected ElementActions Actions { get; private set; }

        public Page(IWebDriver driver)
        {
            Driver = driver;
            Actions = new ElementActions(Driver);
        }
    }
}
