using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopAtlantico.Models
{
  public class Pet
  {
    [Key] public int Id { get; set; }

    [Required]
    [DisplayName("Pet Nome")]
    public string PetName { get; set; }
    
    [DisplayName("Raça")]
    public string Breed { get; set; }

    [Required] public string HospitalizationMotive { get; set; }
    
    [DisplayName("Estado de Saúde")]
    public string HealthState { get; set; }
    public bool Picture { get; set; }

    [Required]
    [DisplayName("Familia")]
    public string OwnerName { get; set; }
    public int PetOwnerId { get; set; }

    public PetOwner PetOwner { get; set; }
  }
}