namespace ParkNet.App.Pages.Users.Transactions;

[Authorize]
public class ProfitsModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public ProfitsModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Transaction> Transaction { get; set; } = default!;
    public double ParcialProfit { get; set; }
    public double Profit { get; set; }


    public async Task OnGetAsync(int months)
    {
        DateTime periods = DateTime.Now.AddMonths(-months);

        List<Transaction> Trans = await _context.Transactions.ToListAsync();

        if (months == 0)
        {
            Trans = await _context.Transactions
                .Include(t => t.User)
                .Where(t => t.InsAndOuts < 0)
                .ToListAsync();
        }
        else
        {
            Trans = await _context.Transactions
                .Include(t => t.User)
                .Where(t => t.InsAndOuts < 0 && t.Datetime >= periods)
                .ToListAsync();
        }

        foreach (Transaction t in Trans)
        {
            t.InsAndOuts = Math.Abs(t.InsAndOuts);
        }

        Transaction = Trans;

        Profit = Transaction.Sum(t => t.InsAndOuts);

    }
}
