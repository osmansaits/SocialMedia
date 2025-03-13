using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public DateTime createdAt { get; set; }
        public bool isDeleted { get; set; }

        public BaseEntity()
        {
            createdAt = DateTime.UtcNow;
            isDeleted = false;
        }

    }
}
