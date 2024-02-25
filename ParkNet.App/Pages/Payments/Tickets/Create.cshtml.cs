namespace ParkNet.App.Pages.Payments.Tickets;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        var availableSpaces = _context.Spaces.Where(s => s.IsOccupied == false);
        var availableVehicles = _context.Vehicles
            .Where(v => !_context.Tickets.Any(t => t.VehicleId == v.Id && t.ExitDateTime == null));
        ViewData["SpaceId"] = new SelectList(availableSpaces, "Id", "Name");
        ViewData["VehicleId"] = new SelectList(availableVehicles, "Id", "LicensePlate");

        Ticket = new Ticket()
        {
            EntryDateTime = DateTime.Now
        };

        return Page();
    }

    [BindProperty]
    public Ticket Ticket { get; set; } = default!;
    [BindProperty]
    public string PickASpace { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Helper.IsBalanceEnough(_context, Ticket.VehicleId) == false)
        {
            ModelState.AddModelError("Ticket.EntryDateTime", "Carregue o seu saldo para poder efetuar esta compra.");
            var availableSpaces = _context.Spaces.Where(s => s.IsOccupied == false);
            var availableVehicles = _context.Vehicles
                .Where(v => !_context.Tickets.Any(t => t.VehicleId == v.Id && t.ExitDateTime == null));
            ViewData["SpaceId"] = new SelectList(availableSpaces, "Id", "Name");
            ViewData["VehicleId"] = new SelectList(availableVehicles, "Id", "LicensePlate");
            return Page();
        }

        if (Helper.OccupiedTrueOrFalse(_context, Ticket.SpaceId) == false)
        {
            Helper.SetToOccupied(_context, Ticket.SpaceId);
        }

        _context.Tickets.Add(Ticket);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
