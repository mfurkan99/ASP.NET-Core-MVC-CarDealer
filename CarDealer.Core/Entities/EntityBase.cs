using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Core.Entities
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set;}

        public DateTime? DeletedDate { get; set; }

        public bool Status { get; set; } = true;
    }
}
