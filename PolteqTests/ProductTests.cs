using Domain;
using Domain.Objects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace PolteqTests
{
    [Collection("SingleThreading")]
    [Trait("UI tests", "Product tests")]
    public class ProductTests : IClassFixture<TestFixture>, IDisposable
    {
        private readonly TestFixture _fixture;
        private readonly ITestOutputHelper _output;


        public ProductTests(ITestOutputHelper output, TestFixture fixture)
        {
            _output = output;
            _fixture = fixture;
            _fixture.Driver.Navigate().GoToUrl(Constants.HomePageUrl);
        }


        public virtual void Dispose()
        {
            _fixture.Driver.Manage().Cookies.DeleteAllCookies();
        }

        [Fact]
        public void BuyProductPayWithBankWire()
        {
            // Assign
            Product selectedProduct;

            // Act
            _fixture.Singletons.HomePage.SelectRandomProduct();
            selectedProduct = _fixture.Singletons.ProductInformationPage.GetProductInformation();
            _fixture.Singletons.ProductInformationPage.AddToCart();
            _fixture.Singletons.ProductAddedModal.GoToCheckOut();
            _fixture.Singletons.SummaryPage.GoToAuthenticationOrAddressPage();
            _fixture.Singletons.AuthenticationPage.Login(_fixture.Credentials);
            _fixture.Singletons.AddressPage.GoToShippingPage();
            _fixture.Singletons.ShippingPage.GoToPaymentPage();
            _fixture.Singletons.PaymentPage.PayWithBankWire();
            _fixture.Singletons.SubmitOrderPage.ConfirmOrder();
            _fixture.Singletons.ConfirmationPage.IsPurchaseSuccesful();

            // Assert
            Assert.True(_fixture.Singletons.ConfirmationPage.IsPurchaseSuccesful(), "Confirmation message is not displayed!");
            Assert.Equal(selectedProduct.Price + Constants.ShippingCost, _fixture.Singletons.ConfirmationPage.GetPaidAmount());
        }

        [Fact]
        public void BuyProductPayWithCheque()
        {
            // Assign
            Product selectedProduct;

            // Act
            _fixture.Singletons.HomePage.SelectRandomProduct();
            selectedProduct = _fixture.Singletons.ProductInformationPage.GetProductInformation();
            _fixture.Singletons.ProductInformationPage.AddToCart();
            _fixture.Singletons.ProductAddedModal.GoToCheckOut();
            _fixture.Singletons.SummaryPage.GoToAuthenticationOrAddressPage();
            _fixture.Singletons.AuthenticationPage.Login(_fixture.Credentials);
            _fixture.Singletons.AddressPage.GoToShippingPage();
            _fixture.Singletons.ShippingPage.GoToPaymentPage();
            _fixture.Singletons.PaymentPage.PayWithCheque();
            _fixture.Singletons.SubmitOrderPage.ConfirmOrder();
            _fixture.Singletons.ConfirmationPage.IsPurchaseSuccesful();

            // Assert
            Assert.True(_fixture.Singletons.ConfirmationPage.IsPurchaseSuccesful(), "Confirmation message is not displayed!");
            Assert.Equal(selectedProduct.Price + Constants.ShippingCost, _fixture.Singletons.ConfirmationPage.GetPaidAmount());
        }
    }
}
