using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace PolteqTests
{
    [Trait("interfaceTest", "test1")]
    public class InterfaceTest
    {
        private IDriver _driver;

        [Fact]
        public void InterfaceTest1()
        {
            var dir = Directory.GetCurrentDirectory().Split("PolteqTests")[0] + "PolteqTests";
            _driver = new Driver(dir);
            _driver.Navigate().GoToUrl("https://www.polteq.com");
        }
    }
}
