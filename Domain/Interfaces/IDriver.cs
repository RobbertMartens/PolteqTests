using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Domain.Interfaces
{
    public interface IDriver
    {
        IWebElement FindElement(By by);
        IWebElement FindElement(By by, bool ignoreDisplayed = false);
        ReadOnlyCollection<IWebElement> FindElements(By by);
        IOptions Manage();
        INavigation Navigate();
        ITargetLocator SwitchTo();
        void Close();
        void Dispose();
        void Quit();
        void Click(IWebElement el);
    }
}
