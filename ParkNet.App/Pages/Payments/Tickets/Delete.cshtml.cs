namespace ParkNet.App.Pages.Payments.Tickets;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Ticket Ticket { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.Id == id);

        if (ticket == null)
        {
            return NotFound();
        }
        else
        {
            Ticket = ticket;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket != null)
        {
            Ticket = ticket;
            _context.Tickets.Remove(Ticket);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
