namespace ParkNet.App.Pages.Parks.Floors;

public class CreateModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
    ViewData["ParkId"] = new SelectList(_context.Parks, "Id", "Name");
        return Page();
    }

    [BindProperty]
    public Floor Floor { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_context.Floors.Any(f => f.Name == Floor.Name && f.ParkId == Floor.ParkId))
        {
            ModelState.AddModelError(string.Empty, "Já existe um andar com esse nome no parque.");
            ViewData["ParkId"] = new SelectList(_context.Parks, "Id", "Name");
            return Page();
        }

        //string[] planUpload = SpaceCreator.GetPlanUpload();
        //Space[,] space = SpaceCreator.SpaceInfo();



        _context.Floors.Add(Floor);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
