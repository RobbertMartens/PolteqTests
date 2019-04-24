using Domain.Pages;
using Domain.Pages.OrderPages;
using Domain.Pages.ProductPages;
using OpenQA.Selenium;

namespace Domain
{
    public sealed class Singletons
    {
        private IWebDriver _driver;
        private Singletons() { }

        private static Singletons _instance;
        public static Singletons Instance => _instance ?? (_instance = new Singletons());

        private DriverFactory _driverFactory;
        public IWebDriver Driver => _driver ?? (_driver = new DriverFactory().GetDriver());

        // General Pages
        private Header _header;
        public Header Header => _header ?? (_header = new Header(_driver));

        private HomePage _homePage;
        public HomePage HomePage => _homePage ?? (_homePage = new HomePage(_driver));

        private AuthenticationPage _authenticationPage;
        public AuthenticationPage AuthenticationPage => _authenticationPage ?? (_authenticationPage = new AuthenticationPage(_driver));

        // Product Pages
        private ProductInformationPage _productInformationPage;
        public ProductInformationPage ProductInformationPage => _productInformationPage ?? (_productInformationPage = new ProductInformationPage(_driver));

        private ProductAddedModal _productAddedModal;
        public ProductAddedModal ProductAddedModal => _productAddedModal ?? (_productAddedModal = new ProductAddedModal(_driver));

        // Order Pages
        private SummaryPage _summaryPage;
        public SummaryPage SummaryPage => _summaryPage ?? (_summaryPage = new SummaryPage(_driver));

        private AddressPage _addressPage;
        public AddressPage AddressPage => _addressPage ?? (_addressPage = new AddressPage(_driver));

        private ShippingPage _shippingPage;
        public ShippingPage ShippingPage => _shippingPage ?? (_shippingPage = new ShippingPage(_driver));

        private PaymentPage _paymentPage;
        public PaymentPage PaymentPage => _paymentPage ?? (_paymentPage = new PaymentPage(_driver));

        private SubmitOrderPage _submitOrderPage;
        public SubmitOrderPage SubmitOrderPage => _submitOrderPage ?? (_submitOrderPage = new SubmitOrderPage(_driver));

        private ConfirmationPage _confirmationPage;
        public ConfirmationPage ConfirmationPage => _confirmationPage ?? (_confirmationPage = new ConfirmationPage(_driver));
    }
}
