using System;

namespace PolteqTests
{
    public class SuiteFixture : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose in SuiteFixture is run");
        }
    }
}
