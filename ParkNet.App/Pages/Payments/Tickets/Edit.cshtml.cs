namespace ParkNet.App.Pages.Payments.Tickets;

[Authorize]
public class EditModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public EditModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Ticket Ticket { get; set; } = default!;

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

        Ticket = ticket;
        var currentSpace = _context.Spaces.Where(s => s.Id == Ticket.SpaceId);
        var currentVehicle = _context.Vehicles.Where(v => v.Id == Ticket.VehicleId);

        ViewData["SpaceId"] = new SelectList(currentSpace, "Id", "Name");
        ViewData["VehicleId"] = new SelectList(currentVehicle, "Id", "LicensePlate");

        Ticket.ExitDateTime = DateTime.Now;

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

        if (Ticket.ExitDateTime <= Ticket.EntryDateTime)
        {
            ModelState.AddModelError("Ticket.ExitDateTime", "A data de saída deve ser posterior à data de entrada.");
            ViewData["SpaceId"] = new SelectList(_context.Spaces, "Id", "Name");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate");
            return Page();
        }

        if (Ticket.ExitDateTime != null && Ticket.ExitDateTime >= Ticket.EntryDateTime)
        {
            Helper.SetToAvailable(_context, Ticket.SpaceId);
        }

        _context.Attach(Ticket).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TicketExists(Ticket.Id))
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

    private bool TicketExists(int id)
    {
        return _context.Tickets.Any(e => e.Id == id);
    }
}
