using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class AuthResponseDto
    {
        public string email { get; set; }
        public ERole role { get; set; }
    }
}
