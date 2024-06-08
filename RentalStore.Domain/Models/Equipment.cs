using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Domain.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }   
        public bool Availability { get; set; }
        public string Condition { get; set; }
        public string Size { get; set; }

        public int QuantityInStock { get; set; }
        public Category Category { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Maintenance> Maintenances { get; set;}
        public ICollection<LocationMap> LocationMaps { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
