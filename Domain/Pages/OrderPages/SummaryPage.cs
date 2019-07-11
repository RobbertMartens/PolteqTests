using Domain.Extensions;
using Domain.Interfaces;
using OpenQA.Selenium;

namespace Domain.Pages.OrderPages
{
    public class SummaryPage : Page
    {
        private IWebElement _proceedToCheckOutButton => Driver.FindElement(By.XPath("//* [@class='button btn btn-default standard-checkout button-medium']"));


        public SummaryPage(IDriver driver) : base(driver) { }


        public void GoToAuthenticationOrAddressPage()
        {
            Driver.Click(_proceedToCheckOutButton);
        }
    }
}
