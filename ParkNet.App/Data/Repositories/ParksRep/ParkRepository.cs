namespace ParkNet.App.Data.Repositories.ParksRep;

public class ParkRepository
{
    private readonly ApplicationDbContext _ctx;

    public ParkRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Park>> GetParksAsync()
    {
        return await _ctx.Parks.ToListAsync();
    }

    public async Task<Park> GetParkByIdAsync(int id)
    {
        return await _ctx.Parks.FindAsync(id);
    }

    public async Task<Park> AddParkAsync(Park park)
    {
        _ctx.Parks.Add(park);
        await _ctx.SaveChangesAsync();
        return park;
    }

    public async Task<Park> UpdateParkAsync(Park park)
    {
        _ctx.Entry(park).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return park;
    }

    public async Task<Park> DeleteParkAsync(int id)
    {
        var park = await _ctx.Parks.FindAsync(id);
        if (park == null)
        {
            return null;
        }

        _ctx.Parks.Remove(park);
        await _ctx.SaveChangesAsync();
        return park;
    }
}
