using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.Accommodations
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PetName"] = new SelectList(_context.Pet, "Id", "PetName");
            return Page();
        }

        [BindProperty]
        public Accommodation Accommodation { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accommodation.Add(Accommodation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
