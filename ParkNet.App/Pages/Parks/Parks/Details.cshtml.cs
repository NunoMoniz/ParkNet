namespace ParkNet.App.Pages.Parks.Parks;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Park Park { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var park = await _context.Parks.FirstOrDefaultAsync(m => m.Id == id);
        if (park == null)
        {
            return NotFound();
        }
        else
        {
            Park = park;
        }
        return Page();
    }
}
