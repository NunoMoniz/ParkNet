using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet.App.Data;
using ParkNet.App.Data.Entities.Payments;

namespace ParkNet.App.Pages.Payments.Tickets
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
        ViewData["SpaceId"] = new SelectList(_context.Spaces, "Id", "Name");
        ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate");
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tickets.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
