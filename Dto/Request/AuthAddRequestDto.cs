using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Request
{
    public class AuthAddRequestDto
    {

        public string  name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isSuccess { get; set; }
        public ERole role { get; set; }
    }
}
