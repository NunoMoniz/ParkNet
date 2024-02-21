namespace ParkNet.App.Pages.Users.Transactions;

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
    public Transaction Transaction { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return Page();
        }

        _context.Transactions.Add(Transaction);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
