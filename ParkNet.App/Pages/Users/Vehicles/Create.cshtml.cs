namespace ParkNet.App.Pages.Users.Vehicles;

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
    ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
        return Page();
    }

    [BindProperty]
    public Vehicle Vehicle { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_context.Vehicles.Any(v => v.LicensePlate == Vehicle.LicensePlate))
        {
            ModelState.AddModelError(string.Empty, "Essa matrícula já está registada.");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return Page();
        }

        if (Vehicle.Type != 'C' && Vehicle.Type != 'M')
        {
            ModelState.AddModelError(string.Empty, "Tipo de veículo inválido.");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return Page();
        }

        _context.Vehicles.Add(Vehicle);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

