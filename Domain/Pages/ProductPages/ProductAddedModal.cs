using Domain.Extensions;
using Domain.Interfaces;
using OpenQA.Selenium;

namespace Domain.Pages.ProductPages
{
    public class ProductAddedModal : Page
    {
        private IWebElement _goToCheckOutButton => Driver.FindElement(By.XPath("//* [@class='btn btn-default button button-medium']"));


        public ProductAddedModal(IDriver driver) : base(driver) { }


        public void GoToCheckOut()
        {
            Driver.Click(_goToCheckOutButton);
        }
    }
}
