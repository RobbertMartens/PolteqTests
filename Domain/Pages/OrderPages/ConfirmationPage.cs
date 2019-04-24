using Domain.Extensions;
using OpenQA.Selenium;

namespace Domain.Pages.OrderPages
{
    public class ConfirmationPage : Page
    {
        private IWebElement _succesAlert => Driver.FindElement(By.XPath("//* [@class='alert alert-success']"));
        private IWebElement _priceText => Driver.FindElement(By.XPath("//* [@class='price']/strong"));


        public ConfirmationPage(IWebDriver driver) : base(driver) { }


        public bool IsPurchaseSuccesful()
        {
            return Actions.IsElementDisplayed(_succesAlert);
        }

        public double GetPaidAmount()
        {
            return _priceText.GetProductPrice();
        }
    }
}
