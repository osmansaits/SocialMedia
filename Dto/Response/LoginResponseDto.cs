﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class LoginResponseDto
    {
        public string token { get; set; }
        public bool isSuccess { get; set; }

    }
}
