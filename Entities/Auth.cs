using Entities.Enums;

namespace Entities
{
    public class Auth : BaseEntity
    {
        public string email { get; set; }
        public string password { get; set; }
        public ERole role { get; set; }
    }
}
