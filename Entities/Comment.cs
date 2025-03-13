using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment:BaseEntity
    {
        public string comment { get; set; }
        public Post post { get; set; }
        public Guid userId { get; set; }
        public User user { get; set; }
    }
}
