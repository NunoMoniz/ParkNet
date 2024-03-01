namespace ParkNet.App.Pages.Parks.Parks;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Park Park { get; set; } = default!;
    [BindProperty]
    public string Confirmation { get; set; }

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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        //if (Confirmation != Park.Name)
        //{
        //    ModelState.AddModelError(string.Empty, "O nome não corresponde.");
        //    return Page();
        //}

        var park = await _context.Parks.FindAsync(id);
        if (park != null)
        {
            Park = park;

            _context.Parks.Remove(Park);
        }

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
