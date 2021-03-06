using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.Pets
{
  public class EditModel : PageModel
  {
    private readonly DataContext _context;

    public EditModel(DataContext context)
    {
      _context = context;
    }

    [BindProperty] public Pet Pet { get; set; }

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

      ViewData["PetOwnerId"] = new SelectList(_context.PetOwner, "Id", "Email");
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Pet).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PetExists(Pet.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return RedirectToPage("./Index");
    }

    private bool PetExists(int id)
    {
      return _context.Pet.Any(e => e.Id == id);
    }
  }
}