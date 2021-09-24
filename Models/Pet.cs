namespace PetShop_Atlantico.Models
{
  public class Pet
  {
    public int Id { get; set; }
    public string PetName { get; set; }
    public string Breed { get; set; }
    public string HospitalizationMotive { get; set; }
    public string HealthState { get; set; }
    public bool Picture { get; set; }
    public string OwnerPetName { get; set; }

    public PetOwner PetOwner { get; set; }
  }
}