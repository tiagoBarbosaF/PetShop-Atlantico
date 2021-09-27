using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopAtlantico.Models
{
    public class Accommodation
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Hospitalization motive")]
        public string HospitalizationMotive { get; set; }
    
        [DisplayName("Health state")]
        public string HealthState { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Accommodation Date")]
        public DateTime AccommodationDate { get; set; }
        
        [DisplayName("Is not Vacant")]
        public bool IsNotVacant { get; set; }
        public int PetId { get; set; }

        public Pet Pet { get; set; }
    }
}