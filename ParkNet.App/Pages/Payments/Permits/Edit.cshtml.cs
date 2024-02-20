using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkNet.App.Data;
using ParkNet.App.Data.Entities.Payments;

namespace ParkNet.App.Pages.Payments.Permits
{
    public class EditModel : PageModel
    {
        private readonly ParkNet.App.Data.ApplicationDbContext _context;

        public EditModel(ParkNet.App.Data.ApplicationDbContext context)
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

            var permit =  await _context.Permits.FirstOrDefaultAsync(m => m.Id == id);
            if (permit == null)
            {
                return NotFound();
            }
            Permit = permit;
           ViewData["SpaceId"] = new SelectList(_context.Spaces, "Id", "Name");
           ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Permit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermitExists(Permit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PermitExists(int id)
        {
            return _context.Permits.Any(e => e.Id == id);
        }
    }
}
