using CarDealer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Entity.Entities
{
    public class Category : EntityBase
    {
        
        public ICollection<Car> Cars { get; set; }
    }
}
