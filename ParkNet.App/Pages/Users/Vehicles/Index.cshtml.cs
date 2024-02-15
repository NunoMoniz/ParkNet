namespace ParkNet.App.Pages.Users.Vehicles;

public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }
    public IList<Vehicle> Vehicle { get; set; } = default!;
    public async Task OnGetAsync()
    {
        Vehicle = await _context.Vehicles
            .Include(v => v.User).ToListAsync();
    }
}
