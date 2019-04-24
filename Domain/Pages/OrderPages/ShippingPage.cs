using OpenQA.Selenium;

namespace Domain.Pages.OrderPages
{
    public class ShippingPage : Page
    {
        private IWebElement _proceedToCheckOutButton => Driver.FindElement(By.XPath("//* [@class='button btn btn-default standard-checkout button-medium']"));
        private IWebElement _acceptTermsCheckBox => Driver.FindElement(By.Id("uniform-cgv"));


        public ShippingPage(IWebDriver driver) : base(driver) { }


        public void GoToPaymentPage()
        {
            _acceptTermsCheckBox.Click();
            Actions.ScrollToElement(_proceedToCheckOutButton);
            _proceedToCheckOutButton.Click();
        }
    }
}
