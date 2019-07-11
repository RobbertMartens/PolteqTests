using OpenQA.Selenium;

namespace Domain.Extensions
{
    public static class WebElementExtensions
    {
        public static double GetProductPrice(this IWebElement el)
        {
            // Cut of euro sign and trim
            var innerText = el.Text.Replace(" ", "").Trim().Split("€")[0].Trim().Replace(" ", ""); 

            // Parse string to double
            var price = double.Parse(innerText);

            return price;
        }

        public static bool IsElementDisplayed(this IWebElement el)
        {
            try
            {
                return el.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }
    }
}
