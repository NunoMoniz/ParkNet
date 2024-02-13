using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet.App.Data;
using ParkNet.App.Data.Entities.Parks;

namespace ParkNet.App.Pages.Parks.Parks
{
    public class CreateModel : PageModel
    {
        private readonly ParkNet.App.Data.ApplicationDbContext _context;

        public CreateModel(ParkNet.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Park Park { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Parks.Add(Park);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
