using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Post
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public List<Illustration> Illustrations { get; set; }
        public int PostType { get; set; }
        // logical delete
        public bool DeletedFlag { get; set; }
        // finished or not
        public bool Status { get; set; }

    }
}
