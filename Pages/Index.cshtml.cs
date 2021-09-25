﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShopAtlantico.Data;
using PetShopAtlantico.Models;

namespace PetShop_Atlantico.Pages
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
        
        [BindProperty]
        public Pet Pet { get; set; }
        
        [BindProperty]
        public PetOwner PetOwner { get; set; }

        public async Task OnGetAsync()
        {
            Pets = await _context.Pets.ToListAsync();
        }
        
        // POST Pets
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pets.Add(Pet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
