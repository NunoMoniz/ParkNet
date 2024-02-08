namespace ParkNet.App.Data.Repositories.PaymentsRep;

public class PermitRepository
{
    private readonly ApplicationDbContext _ctx;

    public PermitRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Permit>> GetAllAsync() => await _ctx.Permits.ToListAsync();

    public async Task<Permit> GetByIdAsync(int id) => await _ctx.Permits.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Permit> AddAsync(Permit permit)
    {
        _ctx.Permits.Add(permit);
        await _ctx.SaveChangesAsync();

        return permit;
    }
}
