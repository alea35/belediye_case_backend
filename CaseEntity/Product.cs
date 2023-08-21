using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEntity
{
    public class Product : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; } 

        public Guid CategoryId{ get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }

    }
}
