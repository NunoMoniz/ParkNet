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

        if (Permit.Months != 1 && Permit.Months != 3 && Permit.Months != 6 && Permit.Months != 12)
        {
            ModelState.AddModelError("Permit.Months", "Avenças disponíveis: 1, 3, 6 e 12 meses.");
            ViewData["SpaceId"] = new SelectList(_context.Spaces, "Id", "Name");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate");
            return Page();
        }

        bool IsOccupied = Helper.OccupiedTrueOrFalse(_context, Permit.SpaceId);
        if (IsOccupied == true)
        {
            ModelState.AddModelError("Permit.SpaceId", "O lugar selecionado já está ocupado.");
            ViewData["SpaceId"] = new SelectList(_context.Spaces, "Id", "Name");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate");
            return Page();
        }

        if (IsOccupied == false)
        {
            Helper.SetToOccupied(_context, Permit.SpaceId);
        }

        Permit.PermitExpiry = Helper.CalculatePermitExpiry(Permit.Months, Permit.PermitAccess);

        _context.Permits.Add(Permit);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
