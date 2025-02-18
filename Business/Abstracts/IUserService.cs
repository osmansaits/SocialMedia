using Dto.Request;
using Entities;

namespace Business.Abstracts
{
    public interface IUserService
    {
        void Add(UserAddRequestDto Dto);
        void Delete(UserDeleteRequestDto Dto);
        public List<User> GetAll();
        public User? GetByEMail(string email);
        public bool isUserExist(string email);
        public bool isValidMail(string email);
    }
}
