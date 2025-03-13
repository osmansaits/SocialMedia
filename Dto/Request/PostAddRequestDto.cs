using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Request
{
    public class PostAddRequestDto
    {
        public string text { get; set; }
        public Auth auth { get; set; }
    }
}
