using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.PetOwners
{
    public class EditModel : PageModel
    {
        private readonly DataContext _context;

        public EditModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PetOwner PetOwner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PetOwner = await _context.PetOwner.FirstOrDefaultAsync(m => m.Id == id);

            if (PetOwner == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PetOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetOwnerExists(PetOwner.Id))
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

        private bool PetOwnerExists(int id)
        {
            return _context.PetOwner.Any(e => e.Id == id);
        }
    }
}
