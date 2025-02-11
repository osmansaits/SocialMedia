using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Auth : BaseEntity
    {
        public string email { get; set; }
        public string password { get; set; }
        public ERole role { get; set; }
    }
}
