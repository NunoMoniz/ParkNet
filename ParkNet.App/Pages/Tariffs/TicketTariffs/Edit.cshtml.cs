namespace ParkNet.App.Pages.Tariffs.TicketTariffs;

[Authorize]
public class EditModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public EditModel(ParkNet.App.Data.ApplicationDbContext context)
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

        var tickettariff =  await _context.TicketsTariff.FirstOrDefaultAsync(m => m.Id == id);
        if (tickettariff == null)
        {
            return NotFound();
        }
        TicketTariff = tickettariff;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(TicketTariff).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TicketTariffExists(TicketTariff.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool TicketTariffExists(int id)
    {
        return _context.TicketsTariff.Any(e => e.Id == id);
    }
}
