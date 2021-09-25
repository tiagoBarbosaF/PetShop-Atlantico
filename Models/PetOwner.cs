using System.ComponentModel.DataAnnotations;

namespace PetShopAtlantico.Models
{
  public class PetOwner
  {
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; }
    public string Address { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
  }
}