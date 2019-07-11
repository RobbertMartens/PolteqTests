using Domain.Helpers;
using Domain.Interfaces;

namespace Domain.Pages
{
    public class Page
    {
        protected IDriver Driver { get; private set; }

        public Page(IDriver driver)
        {
            Driver = driver;
        }
    }
}
