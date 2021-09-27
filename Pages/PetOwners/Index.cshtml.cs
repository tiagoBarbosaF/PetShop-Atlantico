using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopAtlantico.Models;

namespace PetShopAtlantico.Pages.PetOwners
{
  public class IndexModel : PageModel
  {
    private readonly DataContext _context;

    public IndexModel(DataContext context)
    {
      _context = context;
    }

    public IList<PetOwner> PetOwner { get; set; }

    [BindProperty(SupportsGet = true)] public string SearchString { get; set; }
    public SelectList Email { get; set; }

    [BindProperty(SupportsGet = true)] public string PhoneNumber { get; set; }

    public async Task OnGetAsync()
    {
      var owners = from o in _context.PetOwner select o;

      if (!string.IsNullOrEmpty(SearchString))
      {
        owners = owners.Where(o => o.Name.Contains(SearchString));
      }

      PetOwner = await owners.ToListAsync();
    }
  }
}