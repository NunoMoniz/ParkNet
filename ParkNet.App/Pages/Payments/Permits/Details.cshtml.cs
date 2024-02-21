namespace ParkNet.App.Pages.Payments.Permits;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Permit Permit { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var permit = await _context.Permits.FirstOrDefaultAsync(m => m.Id == id);
        if (permit == null)
        {
            return NotFound();
        }
        else
        {
            Permit = permit;
        }
        return Page();
    }
}
