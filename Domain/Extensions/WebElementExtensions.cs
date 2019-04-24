using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class WebElementExtensions
    {
        public static double GetProductPrice(this IWebElement el)
        {
            // Cut of euro sign and trim
            var innerText = el.Text.Split(" ")[0].Trim();

            // Parse string to double
            var price = double.Parse(innerText);

            return price;
        }
    }
}
