using System;

namespace PolteqTests
{
    public class SuiteFixture : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose in SuiteFixture is run");           
        }

        public SuiteFixture()
        {
            Console.WriteLine("Suite fixture is constructed!");
        }

        ~SuiteFixture()
        {
            Console.WriteLine("Destructor is run!");
        }
    }
}
