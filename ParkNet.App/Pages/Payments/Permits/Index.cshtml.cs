namespace ParkNet.App.Pages.Payments.Permits;

public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Permit> Permit { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Permit = await _context.Permits
            .Include(p => p.Space)
            .Include(p => p.Vehicle).ToListAsync();
    }
}
