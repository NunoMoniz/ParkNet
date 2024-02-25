namespace ParkNet.App.Pages.Tariffs.PermitTariffs;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PermitTariff PermitTariff { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var permittariff = await _context.PermitsTariff.FirstOrDefaultAsync(m => m.Id == id);

        if (permittariff == null)
        {
            return NotFound();
        }
        else
        {
            PermitTariff = permittariff;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var permittariff = await _context.PermitsTariff.FindAsync(id);
        if (permittariff != null)
        {
            PermitTariff = permittariff;
            _context.PermitsTariff.Remove(PermitTariff);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
