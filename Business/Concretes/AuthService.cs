using BCrypt.Net;
using Business.Abstracts;
using DataAccess;
using Dto.Request;
using Dto.Response;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Utilities;
using Utilities.Mappers;

namespace Business.Concretes
{
    public class AuthService : IAuthService
    {

        SocialMediaContext _context;
        IJwtService _jwtManager;
        public AuthService(SocialMediaContext context, IJwtService jwtManager)
        {
            _context = context;
            _jwtManager = jwtManager;
        }

        public void Add(AuthAddRequestDto dto)
        {
            if (isAuthExist(dto.email))
            {
                throw new InvalidOperationException(Messages.userAlreadyExist);
            }

            if (isValidMail(dto.email) != true)
            {
                throw new InvalidOperationException(Messages.invalidEmail);
            }

            Auth auth = new Auth(); 
            auth.password=HashPassword(dto.password);
            auth.email=dto.email;
            auth.role = dto.role;
            _context.Add(auth);
            _context.SaveChanges();
        }

        public bool Delete(AuthDeleteRequestDto dto)
        {
            Auth? auth = _context.Auths.SingleOrDefault(x => x.email == dto.email);
            if (auth == null)
            {
                throw new Exception(Messages.userNotFound);
            }
            
            auth.isDeleted = true; // Soft deleted
            _context.SaveChanges();
            return true;
        }
       

        public List<AuthResponseDto> GetAll()
        {

            List<Auth> auths = _context.Auths.ToList();
            List<AuthResponseDto> dtos = new List<AuthResponseDto>();

            foreach (Auth auth in auths)
            {
                AuthResponseDto dto = new AuthResponseDto();
                dto.email = auth.email;
                dto.role = auth.role;
                dtos.Add(dto);
            }
            return dtos;

        }

        public Auth GetByEMail(string email)
        {
            
            Auth? auth = _context.Auths.SingleOrDefault(x => x.email == email);
            if (auth?.email == null)
            {
                throw new Exception(Messages.userNotFound);
            }
           

            return auth;
        }


        public bool isAuthExist(string email)
        {
            Auth? auth = _context.Auths.FirstOrDefault(x => x.email == email);
            return auth != null; // Kullanıcı mevcut ise true, değilse false döner.
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

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(Auth auth, string enteredPassword)
        {

           if (auth == null)
            {
                throw new InvalidOperationException(Messages.userNotFound);
            }

            return BCrypt.Net.BCrypt.Verify(enteredPassword,auth.hashedPassword); //Verify metodu kullanıcının girdiği şifreyi ve dbdeki hashli şifreyi parametre alır.
        }
       
        public LoginResponseDto Login(AuthAddRequestDto dto)
        {
            Auth? auth = GetByEMail(dto.email);
            if (auth == null)
            {
                throw new UnauthorizedAccessException(Messages.userNotFound);
            }

            else if (!VerifyPassword(auth, dto.password))
            {
                throw new UnauthorizedAccessException(Messages.invalidPassword);
            }

            //    LoginResponseDto response = new LoginResponseDto();
            //    response.token =_jwtManager.GenerateJwtToken(auth.id.ToString());
            //    return response;

            string token = _jwtManager.GenerateJwtToken(auth.id.ToString());
            return new LoginResponseDto { token = token };
        }

        //Todo -- Update metodu yaz.
        public bool Update(AuthAddRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Auth? GetById(Guid id)
        {
            return _context.Auths.SingleOrDefault(x => x.id == id);
        }
    }
}