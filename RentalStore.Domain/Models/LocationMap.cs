using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Domain.Models
{
    public class LocationMap
    {
        public int LocationId { get; set; }
        public int EquipmentId { get; set; }
        public string Adress { get; set; }
        public Equipment Equipment { get; set; }

    }
}
