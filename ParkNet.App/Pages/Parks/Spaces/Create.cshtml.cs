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
    [BindProperty]
    public string Input { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        foreach (char c in Input)
        {
            Console.WriteLine((int)c);
            if (c != 'C' && c != 'M' && c != ' ' && c != '\r' && c != '\n')
            {
                ModelState.AddModelError(string.Empty, "A planta do parque apenas permite M, C, espaços e linhas.");
                ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name");
                return Page();
            }
        }

        ParkFactory.Plan(nput);

        _context.Floors.Add(Floors);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}