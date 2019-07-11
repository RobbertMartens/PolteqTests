using Domain.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Domain.Extensions
{
    public static class WebDriverExtensions
    {

        /// <summary>
        /// Waits until an element is visible and returns it
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="ignoreDisplayed"></param>
        /// <returns></returns>
        public static IWebElement WaitAndFindElement(this IWebDriver driver, By by, bool ignoreDisplayed = false)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            return wait.Until(webDriver =>
            {
                if (ignoreDisplayed == false)
                {
                    if (webDriver.FindElement(by).Displayed)
                    {
                        return webDriver.FindElement(by);
                    }
                    return null;
                }
                else
                {
                    if (webDriver.FindElement(by) != null)
                    {
                        return webDriver.FindElement(by);
                    }
                    return null;
                }               
            });
        }

        /// <summary>
        /// Waits until a IReadOnlyCollction can be made and returns it
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> WaitAndFindElements(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            return wait.Until(webDriver =>
            {
                if (webDriver.FindElements(by).Count > 0)
                {
                    return webDriver.FindElements(by);
                }
                return null;
            });
        }

        public static void ClickAndScroll(this IWebDriver driver, IWebElement el)
        {
            var jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();
        }
    }
}
