namespace ParkNet.App.Pages.Tariffs.TicketTariffs;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<TicketTariff> TicketTariff { get;set; } = default!;

    public async Task OnGetAsync()
    {
        TicketTariff = await _context.TariffTickets.ToListAsync();
    }
}
