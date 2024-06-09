using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalStore.Domain.Models;

namespace RentalStore.SharedKernel.Dto
{
    public class RentalDto
    {
        public int RentalId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Rental.RentalStatus Status { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }
}
