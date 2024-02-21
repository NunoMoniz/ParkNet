namespace ParkNet.App.Pages.Tariffs.TicketTariffs;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TicketTariff TicketTariff { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tickettariff = await _context.TariffTickets.FirstOrDefaultAsync(m => m.Id == id);

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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tickettariff = await _context.TariffTickets.FindAsync(id);
        if (tickettariff != null)
        {
            TicketTariff = tickettariff;
            _context.TariffTickets.Remove(TicketTariff);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
