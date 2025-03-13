using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : BaseEntity
    {
        public string name { get; set; }
        public string? lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Comment> comments { get; set; }
        public Auth Auth { get; set; }

    }
}
