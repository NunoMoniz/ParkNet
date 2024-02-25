namespace ParkNet.App.Pages.Tariffs.TicketTariffs;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public TicketTariff TicketTariff { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tickettariff = await _context.TicketsTariff.FirstOrDefaultAsync(m => m.Id == id);
        if (tickettariff == null)
        {
            return NotFound();
        }
        else
        {
            TicketTariff = tickettariff;
        }
        return Page();
    }
}
