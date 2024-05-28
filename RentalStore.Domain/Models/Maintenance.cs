using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Domain.Models
{
    public class Maintenance
    {
        public int MaintenanceId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime MaintenenceDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime? NextMaintenanceDate { get; set; }
        public Equipment Equipment { get; set;}
    }
}
