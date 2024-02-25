namespace ParkNet.App.Pages.Tariffs.PermitTariffs;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<PermitTariff> PermitTariff { get;set; } = default!;

    public async Task OnGetAsync()
    {
        PermitTariff = await _context.PermitsTariff.ToListAsync();
    }
}
