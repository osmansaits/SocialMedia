using Dto.Response;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers
{
    public static class MapToAuthResponseDto
    {
        public static AuthResponseDto ToAuthResponseDto(Auth auth)
        {
            AuthResponseDto authResponseDto = new AuthResponseDto();
            authResponseDto.email = auth.email;
            authResponseDto.role = auth.role;
            return authResponseDto;
        }
    }
}
