using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab2.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string BlogId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
