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
        ViewData["SpaceId"] = new SelectList(Helper.AvailableSpaces(_context), "Id", "Name");
        ViewData["VehicleId"] = new SelectList(Helper.AvailableVehicles(_context), "Id", "LicensePlate");

        Permit = new Permit()
        {
            PermitAccess = DateTime.Now
        };

        return Page();
    }

    [BindProperty]
    public Permit Permit { get; set; } = default!;
    [BindProperty]
    public string DocumentsExpiry { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Helper.IsBalanceEnough(_context, Permit.VehicleId) == false)
        {
            ModelState.AddModelError("Permit.Months", "Carregue o seu saldo para poder efetuar esta compra.");
            ViewData["SpaceId"] = new SelectList(Helper.AvailableSpaces(_context), "Id", "Name");
            ViewData["VehicleId"] = new SelectList(Helper.AvailableVehicles(_context), "Id", "LicensePlate");
            return Page();
        }

        if (Helper.IsItOccupied(_context, Permit.SpaceId) == false)
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
