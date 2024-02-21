namespace ParkNet.App.Pages.Tariffs.TicketTariffs;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public TicketTariff TicketTariff { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.TariffTickets.Add(TicketTariff);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
