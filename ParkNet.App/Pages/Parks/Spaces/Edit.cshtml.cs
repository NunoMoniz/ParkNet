namespace ParkNet.App.Pages.Parks.Spaces;

[Authorize]
public class EditModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public EditModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Space Space { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var space =  await _context.Spaces.FirstOrDefaultAsync(m => m.Id == id);
        if (space == null)
        {
            return NotFound();
        }
        Space = space;
       ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Id");
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

        if (_context.Spaces.Any(s => s.Name == Space.Name && s.FloorId == Space.FloorId))
        {
            ModelState.AddModelError(string.Empty, "Já existe um lugar com esse nome no mesmo piso.");
            ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name");
            return Page();
        }

        _context.Attach(Space).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SpaceExists(Space.Id))
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

    private bool SpaceExists(int id)
    {
        return _context.Spaces.Any(e => e.Id == id);
    }
}
