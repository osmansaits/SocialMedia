using Dto.Request;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers
{
    public class MapToUSer
    {
        public static User ToUser(UserAddRequestDto dto)
        {
            User user = new User();
            user.name = dto.name;
            user.lastName = dto.lastname;
            user.password = dto.password;
            user.email = dto.email;
            return user;
        }
    }
}
