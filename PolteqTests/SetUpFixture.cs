using Domain;
using Microsoft.Win32.SafeHandles;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PolteqTests
{
    // https://xunit.github.io/docs/comparisons

    public class SetUpFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public Singletons Singletons { get; private set; }

        private bool _disposed = false;
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        public SetUpFixture()
        {
            Driver = new ChromeDriver(Directory.GetCurrentDirectory());
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Navigate().GoToUrl(Uris.HomePageUrl);

            Singletons = Singletons.Instance(Driver);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            _disposed = true;
        }
    }
}
