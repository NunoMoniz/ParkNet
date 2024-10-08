﻿namespace ParkNet.App.Pages.Payments.Tickets;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Ticket Ticket { get; set; } = default!;
    public string SpaceName { get; set; } = default!;
    public string VehicleLicensePlate { get; set; }


    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.Id == id);

        if (ticket == null)
        {
            return NotFound();
        }
        else
        {
            Ticket = ticket;
        }

        SpaceName = Helper.GetSpaceName(_context, Ticket.SpaceId);
        VehicleLicensePlate = Helper.GetVehicleLicensePlate(_context, Ticket.VehicleId);

        return Page();
    }
}
