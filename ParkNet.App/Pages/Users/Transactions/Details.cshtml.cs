namespace ParkNet.App.Pages.Users.Transactions;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Transaction Transaction { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transaction = await _context.Transactions.FirstOrDefaultAsync(m => m.Id == id);
        if (transaction == null)
        {
            return NotFound();
        }
        else
        {
            Transaction = transaction;
        }
        return Page();
    }
}
