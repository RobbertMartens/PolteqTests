using OpenQA.Selenium;

namespace Domain.Pages.OrderPages
{
    public class PaymentPage : Page
    {
        private IWebElement _bankWirePaymentButton => Driver.FindElement(By.XPath("//* [@class='bankwire']"));
        private IWebElement _chequePaymentButton => Driver.FindElement(By.XPath("//* [@class='cheque']"));


        public PaymentPage(IWebDriver driver) : base(driver) { }

        
        public void PayWithBankWire()
        {
            _bankWirePaymentButton.Click();
        }

        public void PayWithCheque()
        {
            _chequePaymentButton.Click();
        }
    }
}
