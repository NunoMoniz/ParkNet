using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.App.Data;
using ParkNet.App.Data.Entities.Payments;

namespace ParkNet.App.Pages.Payments.Permits
{
    public class DeleteModel : PageModel
    {
        private readonly ParkNet.App.Data.ApplicationDbContext _context;

        public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Permit Permit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await _context.Permits.FirstOrDefaultAsync(m => m.Id == id);

            if (permit == null)
            {
                return NotFound();
            }
            else
            {
                Permit = permit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await _context.Permits.FindAsync(id);
            if (permit != null)
            {
                Permit = permit;
                _context.Permits.Remove(Permit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
