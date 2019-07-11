using Domain.Extensions;
using Domain.Interfaces;
using OpenQA.Selenium;

namespace Domain.Pages.OrderPages
{
    public class PaymentPage : Page
    {
        private IWebElement _bankWirePaymentButton => Driver.FindElement(By.XPath("//* [@class='bankwire']"));
        private IWebElement _chequePaymentButton => Driver.FindElement(By.XPath("//* [@class='cheque']"));


        public PaymentPage(IDriver driver) : base(driver) { }

        
        public void PayWithBankWire()
        {
            Driver.Click(_bankWirePaymentButton);
        }

        public void PayWithCheque()
        {
            Driver.Click(_chequePaymentButton);
        }
    }
}
