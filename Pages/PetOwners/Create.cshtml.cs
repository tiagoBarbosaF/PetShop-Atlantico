using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.PetOwners
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
            return Page();
        }

        [BindProperty]
        public PetOwner PetOwner { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PetOwner.Add(PetOwner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
