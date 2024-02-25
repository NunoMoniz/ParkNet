namespace ParkNet.App.Pages.Users.Transactions;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Transaction> Transaction { get;set; } = default!;
    public double SumTransactions { get; set; }


    public async Task OnGetAsync()
    {
        Transaction = await _context.Transactions
            .Include(t => t.User).ToListAsync();

        SumTransactions = _context.Transactions.Sum(t => t.InsAndOuts);
    }
}
