namespace ParkNet.App.Pages.Payments.Tickets;

public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Ticket> Ticket { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Ticket = await _context.Tickets
            .Include(t => t.Space)
            .Include(t => t.Vehicle).ToListAsync();
    }
}
