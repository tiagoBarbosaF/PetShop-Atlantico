using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.Accommodations
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _context;

        public DeleteModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Accommodation Accommodation { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accommodation = await _context.Accommodation.FindAsync(id);

            if (Accommodation != null)
            {
                _context.Accommodation.Remove(Accommodation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
