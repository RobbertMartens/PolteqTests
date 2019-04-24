using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Domain
{
    public class DriverFactory
    {
        private IWebDriver _driver;

        public IWebDriver GetDriver()
        {
            var dir = Directory.GetCurrentDirectory().Split("PolteqTests")[0] + "PolteqTests";
            return _driver ?? (new ChromeDriver(dir));
        }
    }
}
