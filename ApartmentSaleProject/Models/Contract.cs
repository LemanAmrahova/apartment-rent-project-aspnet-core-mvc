using System;
using System.Collections.Generic;

namespace ApartmentSaleProject.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public int AId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Price { get; set; }
        public bool? Status { get; set; }

        public virtual Apartment? AIdNavigation { get; set; }
    }
}
