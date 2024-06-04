using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.SharedKernel.Dto
{
    public class LocationMapDto
    {
        public int LocationId { get; set; }
        public int EquipmentId { get; set; }
        public string Adress { get; set; }
        public EquipmentDto Equipment { get; set; }
    }
}
