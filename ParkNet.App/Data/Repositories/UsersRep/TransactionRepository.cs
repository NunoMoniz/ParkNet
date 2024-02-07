namespace ParkNet.App.Data.Repositories.UsersRep;

public class TransactionRepository
{
    private readonly ApplicationDbContext _ctx;

    public TransactionRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    //public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
    //{ }
}
