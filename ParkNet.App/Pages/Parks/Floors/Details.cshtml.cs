namespace ParkNet.App.Pages.Parks.Floors;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Floor Floor { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var floor = await _context.Floors.FirstOrDefaultAsync(m => m.Id == id);
        if (floor == null)
        {
            return NotFound();
        }
        else
        {
            Floor = floor;
        }
        return Page();
    }
}
