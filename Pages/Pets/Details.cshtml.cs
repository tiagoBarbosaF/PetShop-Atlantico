using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Data;
using PetShopAtlantico.Models;

namespace PetShop_Atlantico.Pages.Pets
{
    public class DetailsModel : PageModel
    {
        private readonly PetShopAtlantico.Data.DataContext _context;

        public DetailsModel(PetShopAtlantico.Data.DataContext context)
        {
            _context = context;
        }

        public Pet Pet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pet = await _context.Pets.FirstOrDefaultAsync(m => m.Id == id);

            if (Pet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
