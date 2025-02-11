using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Request
{
    public class UserAddRequestDto
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
