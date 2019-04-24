using Domain.Enumerations;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Domain.Helpers
{
    public class ElementActions
    {
        private readonly IWebDriver _driver;

        public ElementActions(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetElement(Selector selector, string locator)
        {
            try
            {
                switch (selector)
                {
                    case Selector.Id:
                        return _driver.FindElement(By.Id(locator));

                    case Selector.Xpath:
                        return _driver.FindElement(By.XPath(locator));

                    case Selector.Css:
                        return _driver.FindElement(By.CssSelector(locator));

                    //default: throw new Exception($"Invalid selector ({selector})!");
                    default: return null;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.StackTrace); 
                return null;
            }
        }

        public IReadOnlyCollection<IWebElement> GetElements(Selector selector, string locator)
        {
            try
            {
                switch (selector)
                {
                    case Selector.Id:
                        return _driver.FindElements(By.Id(locator));

                    case Selector.Xpath:
                        return _driver.FindElements(By.XPath(locator));

                    case Selector.Css:
                        return _driver.FindElements(By.CssSelector(locator));

                    default: return null;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public bool IsElementDisplayed(IWebElement el)
        {
            try
            {
                return el.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public void ScrollToElement(IWebElement el)
        {
            try
            {
                Actions actions = new Actions(_driver);
                actions.MoveToElement(el);
                actions.Perform();
            }
            catch (StaleElementReferenceException ex)
            {
                Thread.Sleep(3000);
                Actions actions = new Actions(_driver);
                actions.MoveToElement(el);
                actions.Perform();
            }
        }
    }
}
