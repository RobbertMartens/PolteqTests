using Domain.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Domain
{
    public class DriverFactory
    {
        private IDriver _driver;

        public IDriver GetDriver()
        {
            var dir = Directory.GetCurrentDirectory().Split("PolteqTests")[0] + "PolteqTests";
            return _driver ?? (_driver = new Driver(dir));
        }
    }
}
