using OpenQA.Selenium;

namespace Domain.Pages.OrderPages
{
    public class SubmitOrderPage : Page
    {
        private IWebElement _confirmOrderButton => Driver.FindElement(By.XPath("//* [@class='button btn btn-default button-medium']"));


        public SubmitOrderPage(IWebDriver driver) : base(driver) { }


        public void ConfirmOrder()
        {
            _confirmOrderButton.Click();
        }
    }
}
