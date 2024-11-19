using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class BaseEntity<T>
    {
        public T ID { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public bool? isDeleted { get; set; }
    }
}
