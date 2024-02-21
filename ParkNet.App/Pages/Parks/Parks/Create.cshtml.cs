namespace ParkNet.App.Pages.Parks.Parks;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Park Park { get; set; } = default!;

    [BindProperty]
    public string Plan { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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

        foreach (char c in Plan)
        {
            Console.WriteLine((int)c);
            if (c != 'C' && c != 'M' && c != ' ' && c != '\r' && c != '\n')
            {
                ModelState.AddModelError(string.Empty, "A planta do parque apenas permite M, C, espaços e linhas.");
                ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name");
                return Page();
            }
        }

        var newPark = ParkFactory.CreatePark(Park.Name, Plan);

        _context.Parks.Add(newPark);

        _context.SaveChanges();

        foreach (var floor in newPark.Floors)
            _context.Floors.Add(floor);

        await _context.SaveChangesAsync();

        foreach (var floor in newPark.Floors)
        {
            foreach (var space in floor.Spaces)
            {
                _context.Spaces.Add(space);
            }
        }

        _context.Parks.Add(Park);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
