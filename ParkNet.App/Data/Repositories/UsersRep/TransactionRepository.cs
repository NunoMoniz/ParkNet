namespace ParkNet.App.Data.Repositories.UsersRep;

public class TransactionRepository
{
    private readonly ApplicationDbContext _ctx;

    public TransactionRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Transaction>> GetAllAsync() => await _ctx.Transactions.ToListAsync();

    public async Task<Transaction> GetByIdAsync(int id) => await _ctx.Transactions.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Transaction> AddAsync(Transaction transaction)
    {
        _ctx.Transactions.Add(transaction);
        await _ctx.SaveChangesAsync();

        return transaction;
    }
}

