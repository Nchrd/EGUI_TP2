using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab2.Models
{
    public class BlogModel
    {
        public string BlogId { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public List<PostModel> Posts { get; set; }
    }
}
