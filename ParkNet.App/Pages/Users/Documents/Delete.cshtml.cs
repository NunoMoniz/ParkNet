namespace ParkNet.App.Pages.Users.Documents;

public class DeleteModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var document = await _context.Documents.FindAsync(id);
        if (document != null)
        {
            Document = document;
            _context.Documents.Remove(Document);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
