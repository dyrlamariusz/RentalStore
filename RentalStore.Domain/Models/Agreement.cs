using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Domain.Models
{
    public class Agreement
    {
        public int AgreementId { get; set; }
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerIdNumber { get; set; }
        public string CustomerEmail { get; set; } 
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAdress { get; set; }
        public DateTime AgreementDate { get; set; }
        public Rental Rental { get; set; }
    }
}
