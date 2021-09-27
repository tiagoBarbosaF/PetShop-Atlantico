using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.Accommodations
{
  public class EditModel : PageModel
  {
    private readonly DataContext _context;

    public EditModel(DataContext context)
    {
      _context = context;
    }

    [BindProperty] public Accommodation Accommodation { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Accommodation = await _context.Accommodation
        .Include(a => a.Pet).FirstOrDefaultAsync(m => m.Id == id);

      if (Accommodation == null)
      {
        return NotFound();
      }

      ViewData["PetName"] = new SelectList(_context.Pet, "Id", "PetName");
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Accommodation).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AccommodationExists(Accommodation.Id))
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

    private bool AccommodationExists(int id)
    {
      return _context.Accommodation.Any(e => e.Id == id);
    }
  }
}