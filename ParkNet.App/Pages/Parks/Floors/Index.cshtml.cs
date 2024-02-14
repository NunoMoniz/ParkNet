namespace ParkNet.App.Pages.Parks.Floors;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Floor> Floor { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        Floor = await _context.Floors
            .Include(f => f.Park).ToListAsync();
    }
}
