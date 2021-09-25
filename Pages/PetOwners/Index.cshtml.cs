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
    public class IndexModel : PageModel
    {
        private readonly PetShopAtlantico.Data.DataContext _context;

        public IndexModel(PetShopAtlantico.Data.DataContext context)
        {
            _context = context;
        }

        public IList<PetOwner> PetOwner { get;set; }

        public async Task OnGetAsync()
        {
            PetOwner = await _context.PetOwners.ToListAsync();
        }
    }
}
