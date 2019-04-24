using OpenQA.Selenium;

namespace Domain.Pages.ProductPages
{
    public class ProductAddedModal : Page
    {
        private IWebElement _goToCheckOutButton => Driver.FindElement(By.XPath("//* [@class='btn btn-default button button-medium']"));


        public ProductAddedModal(IWebDriver driver) : base(driver) { }


        public void GoToCheckOut()
        {
            _goToCheckOutButton.Click();
        }
    }
}
