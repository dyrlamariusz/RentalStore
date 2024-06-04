using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Application.Dto
{
    public class EquipmentDto
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }   
        public bool Availability { get; set; }
        public string Condition { get; set; }
        public string Size { get; set; }
        //public object Category { get; internal set; }
        /* public CategoryDto Category { get; set; }
public ICollection<RentalDto> Rentals { get; set; }
public ICollection<FeedbackDto> Feedbacks { get; set; }
public ICollection<MaintenanceDto> Maintenances { get; set;}
public ICollection<LocationMapDto> LocationMaps { get; set; }*/

    }
}
