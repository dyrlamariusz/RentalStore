using RentalStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Application.Dto
{
    public class RentalDto
    {
        public int RentalId { get; set; }
        public int EquipmentId { get; set; }
        //public int AgreementId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Rental.RentalStatus Status { get; set; }
    }
}
