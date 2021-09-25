using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Data;
using PetShopAtlantico.Models;

namespace PetShop_Atlantico.Pages.PetOwners
{
    public class DeleteModel : PageModel
    {
        private readonly PetShopAtlantico.Data.DataContext _context;

        public DeleteModel(PetShopAtlantico.Data.DataContext context)
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

            PetOwner = await _context.PetOwners.FirstOrDefaultAsync(m => m.Id == id);

            if (PetOwner == null)
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

            PetOwner = await _context.PetOwners.FindAsync(id);

            if (PetOwner != null)
            {
                _context.PetOwners.Remove(PetOwner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
