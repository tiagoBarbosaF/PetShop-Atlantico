using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Data;
using PetShopAtlantico.Models;

namespace PetShop_Atlantico.Pages.Accommodations
{
    public class DeleteModel : PageModel
    {
        private readonly PetShopAtlantico.Data.DataContext _context;

        public DeleteModel(PetShopAtlantico.Data.DataContext context)
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

            Accommodation = await _context.Accommodations.FirstOrDefaultAsync(m => m.Id == id);

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

            Accommodation = await _context.Accommodations.FindAsync(id);

            if (Accommodation != null)
            {
                _context.Accommodations.Remove(Accommodation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
