using System;
using System.Collections.Generic;

namespace ApartmentSaleProject.Models
{
    public partial class Block
    {
        public Block()
        {
            Apartments = new HashSet<Apartment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
