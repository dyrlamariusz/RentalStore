using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Domain.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int EquipmentId { get; set; }
        //public int? AgreementId { get; set; } // puste agreementid, bo najpierw tworzy sie rental bez agreementid
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentalStatus Status { get; set; }
        public enum RentalStatus
        {
            Active,
            Completed,
            Canceled,
            Overdue
        }
        public DateTime ModifiedAt { get; set; }
    }
}
