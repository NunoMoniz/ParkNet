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

    [BindProperty]
    public Floor Floors { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }


        _context.Floors.Add(Floors);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}