using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
# warning czy to ma byc w ten sposob ? 


namespace RentalStore.SharedKernel.Dto
{
    public class CreateRentalDto
    {
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentalStatusDto Status { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer surname is required.")]
        public string CustomerSurname { get; set; }

        [Required(ErrorMessage = "Customer email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Customer phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string CustomerPhone { get; set; }
        public decimal Total { get; set; }
        public List<CreateRentalDetailDto> Details { get; set; } = new List<CreateRentalDetailDto>();

    }
}
