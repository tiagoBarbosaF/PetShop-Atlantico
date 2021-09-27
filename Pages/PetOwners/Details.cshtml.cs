using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.PetOwners
{
    public class DetailsModel : PageModel
    {
        private readonly DataContext _context;

        public DetailsModel(DataContext context)
        {
            _context = context;
        }

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
    }
}
