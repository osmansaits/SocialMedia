using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table ("Auths")]
    public class Auth : BaseEntity
    {
    
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Required]
        [MinLength(8)]
        public string password { get; set; }
        public string hashedPassword { get; set; }
        public ERole role { get; set; }
    }
}
