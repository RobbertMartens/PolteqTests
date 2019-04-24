using Domain;
using Domain.Helpers;
using Domain.Objects;
using Microsoft.Win32.SafeHandles;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;

namespace PolteqTests
{
    // https://xunit.github.io/docs/comparisons

    public class TestFixture : ICollectionFixture<SuiteFixture>, IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public Singletons Singletons { get; private set; }
        public Credentials Credentials { get; private set; }

        private bool _disposed = false;
        private readonly bool _shouldLog; 
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private readonly ConfigFileReader _config;


        public TestFixture()
        {
            Singletons = Singletons.Instance;
            Driver = Singletons.Driver;

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Navigate().GoToUrl(Constants.HomePageUrl);

            _config = new ConfigFileReader();
            Credentials = _config.GetCredentials();
            _shouldLog = _config.GetShouldLog();
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
