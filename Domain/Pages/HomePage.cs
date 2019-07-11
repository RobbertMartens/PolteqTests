using Domain.Interfaces;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace Domain.Pages
{
    public class HomePage : Page
    {
        public HomePage(IDriver driver) : base(driver) { }

        public void SelectRandomProduct()
        {
            int i = 0;
            while (i < 4)
            {
                var products = Driver.FindElements(By.XPath("//* [@class='left-block']"));
                var product = products.ElementAt(new Random().Next(0, products.Count));
                Driver.Click(product);
                var availableElement = Driver.FindElement(By.Id("availability_value"), true);

                if (availableElement.Text == "In stock" || availableElement.Text.Length == 0)
                {
                    break;
                }
                Driver.Navigate().Back();
                i++;
            }            
        }
    }
}
