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
    //public string Plan { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }


        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

