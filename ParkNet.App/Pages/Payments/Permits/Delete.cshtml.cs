namespace ParkNet.App.Pages.Payments.Permits;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var permit = await _context.Permits.FindAsync(id);
        if (permit != null)
        {
            Permit = permit;
            Helper.SetToAvailable(_context, permit.SpaceId);
            _context.Permits.Remove(Permit);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
