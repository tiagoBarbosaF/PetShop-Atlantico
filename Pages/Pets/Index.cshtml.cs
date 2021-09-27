using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.Pets
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get;set; }
        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }
        public SelectList Breed { get; set; }

        [BindProperty(SupportsGet = true)] public string OwnerPet { get; set; }

        public async Task OnGetAsync()
        {
            var pets = from p in _context.Pet select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                pets = pets.Where(p => p.PetName.Contains(SearchString));
            }
            
            Pet = await pets.ToListAsync();
        }
    }
}
