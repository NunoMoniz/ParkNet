using ParkNet.App.Data.Entities.Payments;

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
    ViewData["SpaceId"] = new SelectList(_context.Spaces, "Id", "Name");
    ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate");
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

        Permit.PermitExpiry = Helper.CalculatePermitExpiry(Permit.Name, Permit.PermitAccess);

        _context.Permits.Add(Permit);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
