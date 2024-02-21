namespace ParkNet.App.Pages.Parks.Spaces;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Space Space { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var space = await _context.Spaces.FirstOrDefaultAsync(m => m.Id == id);
        if (space == null)
        {
            return NotFound();
        }
        else
        {
            Space = space;
        }
        return Page();
    }
}
