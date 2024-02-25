namespace ParkNet.App.Pages.Payments.Permits;

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
            .Where(v => !_context.Permits.Any(p => p.VehicleId == v.Id && p.PermitExpiry > DateTime.Now));
        ViewData["SpaceId"] = new SelectList(availableSpaces, "Id", "Name");
        ViewData["VehicleId"] = new SelectList(availableVehicles, "Id", "LicensePlate");

        Permit = new Permit()
        {
            PermitAccess = DateTime.Now
        };

        return Page();
    }

    [BindProperty]
    public Permit Permit { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        bool enoughBalance = Helper.IsBalanceEnough(_context, Permit.VehicleId);

        if (enoughBalance == false)
        {
            ModelState.AddModelError("Permit.Months", "Carregue o seu saldo para poder efetuar esta compra.");
            var availableSpaces = _context.Spaces.Where(s => s.IsOccupied == false);
            var availableVehicles = _context.Vehicles
                .Where(v => !_context.Permits.Any(p => p.VehicleId == v.Id && p.PermitExpiry > DateTime.Now));
            ViewData["SpaceId"] = new SelectList(availableSpaces, "Id", "Name");
            ViewData["VehicleId"] = new SelectList(availableVehicles, "Id", "LicensePlate");
            return Page();
        }

        bool IsOccupied = Helper.OccupiedTrueOrFalse(_context, Permit.SpaceId);

        if (IsOccupied == false)
        {
            Helper.SetToOccupied(_context, Permit.SpaceId);
        }

        Permit.PermitExpiry = Helper.CalculatePermitExpiry(Permit.Months, Permit.PermitAccess);

        Transaction transaction = Helper.PermitPaymentCalculator(_context, Permit.VehicleId, Permit.Months);

        _context.Transactions.Add(transaction);

        _context.Permits.Add(Permit);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
