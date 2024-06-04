using System.ComponentModel.DataAnnotations;


namespace RentalStore.SharedKernel.Dto
{
    public class CreateEquipmentDto
    {
        public string Name { get; set; }
        //public int CategoryId { get; set; }
        //nowe pole zamiast id:
        public string CategoryName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool Availability { get; set; }
        public string Condition { get; set; }
        public string Size { get; set; }
        /*public CategoryDto Category { get; set; }
        public ICollection<RentalDto> Rentals { get; set; }
        public ICollection<FeedbackDto> Feedbacks { get; set; }
        public ICollection<MaintenanceDto> Maintenances { get; set; }
        public ICollection<LocationMapDto> LocationMaps { get; set; }*/
    }
 
}