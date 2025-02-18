using Business.Abstracts;
using DataAccess;
using Dto.Request;
using Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.RegularExpressions;
using Utilities;
using Utilities.Mappers;

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
            if (isUserExist(dto.email))
            {
                throw new InvalidOperationException(Messages.userAlreadyExist);
            }

            if (isValidMail(dto.email) != true)
            {
                throw new InvalidOperationException(Messages.invalidEmail);
            }

            User user = MapToUSer.ToUser(dto);
            _context.Add(user);
            _context.SaveChanges();



        }

        public void Delete(UserDeleteRequestDto dto)
        {

            User? user = GetByEMail(dto.email);

            if (user?.email != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            throw new InvalidOperationException(Messages.userAlreadyExist);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetByEMail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.email == email);
        }

        public bool isUserExist(string email)
        {

            User? user = _context.Users.SingleOrDefault(x => x.email == email);

            return user != null;
        }

        public bool isValidMail(string email)
        {
            var regex = new Regex(@"^(?!.*@yahoo\.com$)(.*@(gmail\.com|hotmail\.com))$");
            if (regex.IsMatch(email))
            {
                return true;
            }
            return false;
        }
    }
}
