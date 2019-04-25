using Domain;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PolteqTests
{
    [Collection("SingleThreading")]
    [Trait("Api tests", "Testing first connections..")]
    public class ApiTests
    {
        private readonly ApiHelper _api;
        private readonly ITestOutputHelper _output;
        private readonly DataGenerator _dataGenerator;

        public ApiTests(ITestOutputHelper output)
        {
            _output = output;
            _api = new ApiHelper(_output);
            _dataGenerator = new DataGenerator();
        }

        [Fact]
        public async Task GetPosts()
        {           
            var posts = await _api.GetPosts();
            Assert.InRange(posts.Count, 100, 100);
        }

        [Fact]
        public async Task PostPost()
        {
            // Assign
            var post = _dataGenerator.GeneratePost();

            // Act
            var response = await _api.PostPost(post);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
