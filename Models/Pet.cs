using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopAtlantico.Models
{
  public class Pet
  {
    public int Id { get; set; }

    [Required]
    [DisplayName("Pet Name")]
    public string PetName { get; set; }
    
    [DisplayName("Race/Specie")]
    public string Breed { get; set; }
    public bool Picture { get; set; }

    [Required]
    [DisplayName("Family")]
    public string OwnerName { get; set; }
    
    [DisplayName("Pet owner email")]
    public int PetOwnerId { get; set; }

    public PetOwner PetOwner { get; set; }
  }
}