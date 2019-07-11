using Domain.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace Domain.Interfaces
{
    public class Driver : IDriver
    {
        public string Url {get; set;}
        public string Title => _driver.Title;
        public string PageSource => _driver.PageSource;
        public string CurrentWindowHandle => _driver.CurrentWindowHandle;
        public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        private IWebDriver _driver;


        public Driver(string dir)
        {
            _driver = new ChromeDriver(dir);
        }

        public IWebElement FindElement(By by)
        {
            return _driver.WaitAndFindElement(by);
        }

        public IWebElement FindElement(By by, bool ignoreDisplayed = false)
        {
            return _driver.WaitAndFindElement(by, ignoreDisplayed);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.WaitAndFindElements(by);
        }

        public IOptions Manage()
        {
            return _driver.Manage();
        }

        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }

        public void Close()
        {
            _driver.Close();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void Click(IWebElement el)
        {
            _driver.ClickAndScroll(el);
        }
    }
}
