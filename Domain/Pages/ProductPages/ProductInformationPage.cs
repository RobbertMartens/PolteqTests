using Domain.Extensions;
using Domain.Objects;
using OpenQA.Selenium;

namespace Domain.Pages.ProductPages
{
    public class ProductInformationPage : Page
    {
        private IWebElement _productNameElement => Driver.FindElement(By.XPath("//* [@itemprop='name']"));
        private IWebElement _productPriceElement => Driver.FindElement(By.Id("our_price_display"));
        private IWebElement _addToCartButton => Driver.FindElement(By.XPath("//* [@name='Submit']"));


        public ProductInformationPage(IWebDriver driver) : base(driver) { }


        public Product GetProductInformation()
        {
            var product = new Product
            {
                Name = _productNameElement.Text,
                Price = _productPriceElement.GetProductPrice()
            };
            return product;
        }

        public void AddToCart()
        {
            _addToCartButton.Click();
        }
    }
}
