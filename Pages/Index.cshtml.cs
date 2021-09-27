using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IList<Pet> Pets { get; set; }
        public IList<Accommodation> Accommodations { get; set; }
        public IList<PetOwner> PetOwners { get; set; }
        
        [BindProperty]
        public Pet Pet { get; set; }
        
        [BindProperty]
        public Accommodation Accommodation { get; set; }
        
        [BindProperty]
        public PetOwner PetOwner { get; set; }

        public async Task OnGetAsync()
        {
            Pets = await _context.Pet.ToListAsync();
            Accommodations = await _context.Accommodation.ToListAsync();
            PetOwners = await _context.PetOwner.ToListAsync();
        }
    }
}
