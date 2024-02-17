namespace ParkNet.App.Pages.Parks.Spaces;
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
        ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name");
        return Page();
    }

    //[BindProperty]
    //public Space Space { get; set; } = default!;
    [BindProperty]
    public List<Space> Spaces { get; set; } = default!;
    //[BindProperty]
    //public string UserInput { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        //if (_context.Spaces.Any(s => s.Name == Space.Name && s.FloorId == Space.FloorId))
        //{
        //    ModelState.AddModelError(string.Empty, "Já existe um lugar com esse nome no mesmo piso.");
        //    ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name");
        //    return Page();
        //}

        //SpaceCreator.planUpload = UserInput.Split("\n");
        Spaces = SpaceCreator.SpaceInfo(1);

        _context.Spaces.AddRange(Spaces);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}