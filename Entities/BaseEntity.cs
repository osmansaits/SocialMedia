using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseEntity
    {
        public Guid id { get; set; }
        public DateTime createdAt { get; set; }
        public  bool isDeleted { get; set; }

        public BaseEntity()
        {
            createdAt = DateTime.UtcNow;
            isDeleted = false;
        }

    }
}
