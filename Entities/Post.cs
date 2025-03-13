using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Post:BaseEntity
    {
        public string text { get; set; }
        public List<Comment> comment { get; set; }
        public User user { get; set; }
    }
}
