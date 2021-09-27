using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAtlantico.Models
{
  public class SeedData
  {
    public static async Task Seed(DataContext context)
    {
        if (context.PetOwner.Any()) return;

        var petOwners = new List<PetOwner>
        {
          new PetOwner
          {
            Name = "Jon Snow",
            Address = "North Westeros",
            PhoneNumber = "66998765432",
            Email = "idontknownothing@gmail.com"
          },
          new PetOwner
          {
            Name = "Tiago Barbosa",
            Address = "Rua das Flores, 1010",
            PhoneNumber = "85991234567",
            Email = "tiago@gmail.com"
          },
          new PetOwner
          {
            Name = "Rakel",
            Address = "Av. Luz, 2020",
            PhoneNumber = "85985672309",
            Email = "rakel@gmail.com"
          }
        };

        await context.PetOwner.AddRangeAsync(petOwners);
        await context.SaveChangesAsync();
    }
  }
}