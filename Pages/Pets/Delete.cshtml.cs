using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.Pets
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _context;

        public DeleteModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pet = await _context.Pet.FindAsync(id);

            if (Pet != null)
            {
                _context.Pet.Remove(Pet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
