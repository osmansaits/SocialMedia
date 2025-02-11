using Dto.Request;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        void Add(UserAddRequestDto Dto);
        void Delete(UserDeleteRequestDto Dto);
    }
}
