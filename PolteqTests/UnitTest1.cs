using Domain;
using Domain.Pages;
using Xunit;
using Xunit.Abstractions;

namespace PolteqTests
{
    public class UnitTest1 : IClassFixture<SetUpFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly SetUpFixture _fixture;

        public UnitTest1(ITestOutputHelper output, SetUpFixture fixture)
        {
            _output = output;
            _fixture = fixture;
            _output.WriteLine("test class constructed!");
            _fixture.Driver.Navigate().GoToUrl(Uris.HomePageUrl);
        }


        [Fact]
        public void Test1()
        {
            _fixture.Singletons.Header.ClickLogin();
            _output.WriteLine("Test was run!");
            _fixture.Dispose();
        }

        [Fact]
        public void Test2()
        {
            _fixture.Singletons.Header.ClickLogin();
            _output.WriteLine("Test was run!");
            _fixture.Dispose();
        }
    }
}
