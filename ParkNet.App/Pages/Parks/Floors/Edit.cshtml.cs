namespace ParkNet.App.Pages.Parks.Floors;

[Authorize]
public class EditModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public EditModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Floor Floor { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var floor =  await _context.Floors.FirstOrDefaultAsync(m => m.Id == id);
        if (floor == null)
        {
            return NotFound();
        }
        Floor = floor;
       ViewData["ParkId"] = new SelectList(_context.Parks, "Id", "Name");
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

        if (_context.Floors.Any(f => f.Number == Floor.Number && f.ParkId == Floor.ParkId))
        {
            ModelState.AddModelError(string.Empty, "Já existe um andar com esse nome no parque.");
            ViewData["ParkId"] = new SelectList(_context.Parks, "Id", "Name");
            return Page();
        }

        _context.Attach(Floor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FloorExists(Floor.Id))
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

    private bool FloorExists(int id)
    {
        return _context.Floors.Any(e => e.Id == id);
    }
}
