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
        //public int EquipmentId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentalStatusDto Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public decimal Total { get; set; }
        public List<CreateRentalDetailDto> Details { get; set; } = new List<CreateRentalDetailDto>();

    }
}
