using Dto.Request;
using Dto.Response;
using Entities;
using System.Reflection.Metadata.Ecma335;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        void Add(AuthAddRequestDto dto);
        bool Delete(AuthDeleteRequestDto dto);
        bool Update(AuthAddRequestDto dto);
        public LoginResponseDto Login(AuthAddRequestDto dto);
        public List<AuthResponseDto> GetAll();
        public Auth? GetById(Guid id);
        public Auth? GetByEMail(string email);
        public string HashPassword(string password);
        public bool VerifyPassword(Auth auth, string enteredPassword);
        public bool isAuthExist(string email);
        public bool isValidMail(string email);
        
    }
}
