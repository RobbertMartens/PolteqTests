using Domain.Extensions;
using Domain.Interfaces;
using OpenQA.Selenium;

namespace Domain.Pages.OrderPages
{
    public class ConfirmationPage : Page
    {
        private IWebElement _succesAlert => Driver.FindElement(By.XPath("//* [@class='alert alert-success']"));
        private IWebElement _priceText => Driver.FindElement(By.XPath("//* [@class='price']/strong"));


        public ConfirmationPage(IDriver driver) : base(driver) { }


        public bool IsPurchaseSuccesful()
        {
            return _succesAlert.IsElementDisplayed();
        }

        public double GetPaidAmount()
        {
            return _priceText.GetProductPrice();
        }
    }
}
