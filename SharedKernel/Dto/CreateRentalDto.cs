using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
# warning czy to ma byc w ten sposob ? 
using static RentalStore.Domain.Models.Rental;


namespace RentalStore.SharedKernel.Dto
{
    public class CreateRentalDto
    {
        public int EquipmentId { get; set; }
        //public int AgreementId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentalStatus Status { get; set; }
    }
}
