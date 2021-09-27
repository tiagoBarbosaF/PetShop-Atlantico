using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.Accommodations
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IList<Accommodation> Accommodation { get;set; }
        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }
        public SelectList HealState { get; set; }

        [BindProperty(SupportsGet = true)] public string OwnerPet { get; set; }

        public async Task OnGetAsync()
        {
            var accommodations = from a in _context.Accommodation select a;

            if (!string.IsNullOrEmpty(SearchString))
            {
                accommodations = accommodations.Where(a => a.Pet.PetName.Contains(SearchString));
            }
            
            Accommodation = await accommodations.ToListAsync();
        }
    }
}
