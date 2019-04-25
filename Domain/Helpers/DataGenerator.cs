using Domain.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public class DataGenerator
    {
        private readonly Random rdm;

        public DataGenerator()
        {
            rdm = new Random();
        }

        public Post GeneratePost()
        {
            var post = new Post
            {
                UserId = rdm.Next(1, 200),
                Id = rdm.Next(1, 200),
                Title = "Super vet!",
                Completed = true
            };
            return post;
        }
    }
}
