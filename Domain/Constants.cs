namespace Domain
{
    public static class Constants
    {
        public static double ShippingCost { get; } = 2.38;
        public static string HomePageUrl { get; } = "https://techblog.polteq.com/testshop";

        public static class ApiUris
        {
            public static string BaseUri = "https://jsonplaceholder.typicode.com";

            /// <summary>
            /// GET and POST
            /// </summary>
            public static string Posts = "/posts";
        }
    }
}
