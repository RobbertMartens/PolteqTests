using Domain.Enumerations;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace Domain.Pages
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public void SelectRandomProduct()
        {
            var products = Actions.GetElements(Selector.Xpath, "//* [@class='left-block']");
            var product = products.ElementAt(new Random().Next(0, products.Count));
            Actions.ScrollToElement(product);
            product.Click();
        }
    }
}
