namespace ParkNet.App.Pages.Parks.Floors;
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
        ViewData["ParkId"] = new SelectList(_context.Parks, "Id", "Name");
        return Page();
    }

    [BindProperty]
    public Floor Floor { get; set; } = default!;
    //[BindProperty]
    //public string UserInput { get; set; }

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

        //SpaceCreator.planUpload = UserInput.Split("\n");
        //List<Space> spaces = SpaceCreator.SpaceInfo(Floor.Id);
        //List<Space> spaces = SpaceCreator.SpaceInfo(1);
        //_context.Spaces.AddRange(spaces);

        _context.Floors.Add(Floor);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

