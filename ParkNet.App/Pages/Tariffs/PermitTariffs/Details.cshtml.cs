namespace ParkNet.App.Pages.Tariffs.PermitTariffs;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public PermitTariff PermitTariff { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var permittariff = await _context.TariffPermits.FirstOrDefaultAsync(m => m.Id == id);
        if (permittariff == null)
        {
            return NotFound();
        }
        else
        {
            PermitTariff = permittariff;
        }
        return Page();
    }
}
