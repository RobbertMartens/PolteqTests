using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Objects
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
