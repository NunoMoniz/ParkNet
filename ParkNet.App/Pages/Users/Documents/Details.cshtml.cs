namespace ParkNet.App.Pages.Users.Documents;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Document Document { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var document = await _context.Documents.FirstOrDefaultAsync(m => m.Id == id);
        if (document == null)
        {
            return NotFound();
        }
        else
        {
            Document = document;
        }
        return Page();
    }
}
