using Domain.Extensions;
using Domain.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Domain
{
    public class ApiHelper
    {
        private HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;

        public ApiHelper(ITestOutputHelper testOutputHelper)
        {
            _client = new HttpClient();
            _testOutputHelper = testOutputHelper;
        }

        public async Task<List<Post>> GetPosts()
        {
            var response = await _client.GetAsync(Constants.ApiUris.BaseUri + Constants.ApiUris.Posts);
            var posts = response.GetContent<List<Post>>(_testOutputHelper);
            return posts;            
        }

        public async Task<HttpResponseMessage> PostPost(Post post)
        {            
            var httpContent = new StringContent(JsonConvert.SerializeObject(post));
            var response = await _client.PostAsync(Constants.ApiUris.BaseUri + Constants.ApiUris.Posts, httpContent);
            return response;
        }
    }
}
