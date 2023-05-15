using System;
using System.Collections.Generic;

namespace ApartmentSaleProject.Models
{
    public partial class Apartment
    {
        public Apartment()
        {
            Contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public int BId { get; set; }
        public int Number { get; set; }
        public int NumOfRooms { get; set; }
        public double Kv { get; set; }
        public double Price { get; set; }
        public bool? Status { get; set; }

        public virtual Block? BIdNavigation { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
