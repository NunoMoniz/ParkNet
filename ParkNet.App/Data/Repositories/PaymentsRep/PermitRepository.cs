namespace ParkNet.App.Data.Repositories.PaymentsRep;

public class PermitRepository
{
    private readonly ApplicationDbContext _ctx;

    public PermitRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Permit>> GetPermitsAsync()
    {
        return await _ctx.Permits.ToListAsync();
    }

    public async Task<Permit> GetPermitByIdAsync(int id)
    {
        return await _ctx.Permits.FindAsync(id);
    }

    public async Task<Permit> AddPermitAsync(Permit permit)
    {
        _ctx.Permits.Add(permit);
        await _ctx.SaveChangesAsync();
        return permit;
    }

    public async Task<Permit> UpdatePermitAsync(Permit permit)
    {
        _ctx.Entry(permit).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return permit;
    }

    public async Task<Permit> DeletePermitAsync(int id)
    {
        var permit = await _ctx.Permits.FindAsync(id);
        if (permit == null)
        {
            return null;
        }

        _ctx.Permits.Remove(permit);
        await _ctx.SaveChangesAsync();
        return permit;
    }
}
