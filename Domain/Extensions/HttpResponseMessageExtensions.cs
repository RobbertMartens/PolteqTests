using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit.Abstractions;

namespace Domain.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static T GetContent<T> (this HttpResponseMessage response, ITestOutputHelper testOutputHelper)
        {
            if (response.IsSuccessStatusCode)
            {
                var jsonBody = response.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<T>(jsonBody);
                return content;
            }
            else
            {
                var reasonPhrase = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject(reasonPhrase);
                var prettyMessage = JsonConvert.SerializeObject(obj, Formatting.Indented);
                testOutputHelper.WriteLine(prettyMessage);
                return default(T);
            }
        }
    }
}
