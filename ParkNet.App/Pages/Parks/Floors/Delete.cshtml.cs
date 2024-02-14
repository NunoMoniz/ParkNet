using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.App.Data;
using ParkNet.App.Data.Entities.Parks;

namespace ParkNet.App.Pages.Parks.Floors
{
    public class DeleteModel : PageModel
    {
        private readonly ParkNet.App.Data.ApplicationDbContext _context;

        public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Floor Floor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var floor = await _context.Floors.FirstOrDefaultAsync(m => m.Id == id);

            if (floor == null)
            {
                return NotFound();
            }
            else
            {
                Floor = floor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var floor = await _context.Floors.FindAsync(id);
            if (floor != null)
            {
                Floor = floor;
                _context.Floors.Remove(Floor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
