using System.ComponentModel.DataAnnotations;

// DO USUNIECIA

namespace RentalStore.SharedKernel.Dto
{
    public class UpdateEquipmentDto
    {
        //public int EquipmentId { get; set; } ZAKOMENTOWANE BO NIE CHCEMY MIEĆ ID PODCZAS UPDATE
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool Availability { get; set; }
        public string Condition { get; set; }
        public string Size { get; set; }
        
    }

    
}