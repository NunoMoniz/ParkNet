namespace ParkNet.App.Pages.Payments.Permits;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public Permit Permit { get; set; } = default!;
    public string SpaceName { get; set; } = default!;
    public string VehicleLicensePlate { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userName = User.Identity.Name;

        var permit = await _context.Permits.FirstOrDefaultAsync(m => m.Id == id);
        if (permit == null)
        {
            return NotFound();
        }
        else
        {
            Permit = permit;
        }

        SpaceName = Helper.GetSpaceName(_context, Permit.SpaceId);
        VehicleLicensePlate = Helper.GetVehicleLicensePlate(_context, Permit.VehicleId);

        return Page();
    }
}
