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
        private IWebElement _productNotInStockModal => Driver.FindElement(By.XPath("//* [@title='Close']"));


        public ProductInformationPage(IWebDriver driver) : base(driver) { }


        public Product AddToCart()
        {
            if (_addToCartButton.Displayed)
            {
                var product = GetProductInformation();
                _addToCartButton.Click();
                return product;
            }
            else
            {
                var altProdcut = Driver.FindElement(By.XPath("//* [@class='replace-2x img-responsive']"));
                altProdcut.Click();
                var product = GetProductInformation();
                return product;
            }
        }

        private Product GetProductInformation()
        {
            var product = new Product
            {
                Name = _productNameElement.Text,
                Price = _productPriceElement.GetProductPrice()
            };
            return product;
        }
    }
}
