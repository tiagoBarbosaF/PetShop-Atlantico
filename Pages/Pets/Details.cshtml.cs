using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.Pets
{
  public class DetailsModel : PageModel
  {
    private readonly DataContext _context;

    public DetailsModel(DataContext context)
    {
      _context = context;
    }

    public Pet Pet { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Pet = await _context.Pet
        .Include(p => p.PetOwner).FirstOrDefaultAsync(m => m.Id == id);

      if (Pet == null)
      {
        return NotFound();
      }

      return Page();
    }
  }
}