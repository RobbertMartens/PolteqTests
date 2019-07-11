using Domain.Extensions;
using Domain.Interfaces;
using OpenQA.Selenium;

namespace Domain.Pages.OrderPages
{
    public class AddressPage : Page
    {
        private IWebElement _proceedToCheckOutButton => Driver.FindElement(By.XPath("//* [@class='button btn btn-default button-medium']"));


        public AddressPage(IDriver driver) : base(driver) { }


        public void GoToShippingPage()
        {
            Driver.Click(_proceedToCheckOutButton);
        }
    }
}
