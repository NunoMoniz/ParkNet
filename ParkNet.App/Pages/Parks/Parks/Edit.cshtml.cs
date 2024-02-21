namespace ParkNet.App.Pages.Parks.Parks;

[Authorize]
public class EditModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public EditModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Park Park { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var park =  await _context.Parks.FirstOrDefaultAsync(m => m.Id == id);
        if (park == null)
        {
            return NotFound();
        }
        Park = park;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_context.Parks.Any(p => p.Name == Park.Name))
        {
            ModelState.AddModelError(string.Empty, "Já existe um parque com o mesmo nome.");
            ViewData["ParkId"] = new SelectList(_context.Parks, "Id", "Name");
            return Page();
        }

        _context.Attach(Park).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParkExists(Park.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ParkExists(int id)
    {
        return _context.Parks.Any(e => e.Id == id);
    }
}
