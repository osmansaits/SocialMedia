using Business.Abstracts;
using DataAccess;
using Dto.Request;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserService : IUserService
    {
        
        SocialMediaContext _context;
        

        public UserService(SocialMediaContext context)
        {
            _context = context;
        }
        public void Add(UserAddRequestDto dto)
        {
            User user = new User();
            user.name=dto.name;
            user.lastName = dto.lastname;
            user.email = dto.email;
            user.password=dto.password;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(UserDeleteRequestDto dto)
        {
            #region map
            User user =new User();
            user.name=dto.name;
            user.lastName=dto.lastname;
            user.email=dto.email;
            user.password = dto.password;
            #endregion
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
