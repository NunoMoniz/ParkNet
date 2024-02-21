namespace ParkNet.App.Pages.Users.Documents;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Document> Document { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Document = await _context.Documents
            .Include(d => d.User).ToListAsync();
    }
}
