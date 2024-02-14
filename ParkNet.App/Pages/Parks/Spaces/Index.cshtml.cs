namespace ParkNet.App.Pages.Parks.Spaces;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Space> Space { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        Space = await _context.Spaces
            .Include(s => s.Floor).ToListAsync();
    }
}
