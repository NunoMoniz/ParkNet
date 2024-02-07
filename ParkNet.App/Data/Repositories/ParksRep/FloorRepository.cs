namespace ParkNet.App.Data.Repositories.ParksRep;

public class FloorRepository
{
    private readonly ApplicationDbContext _ctx;

    public FloorRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Floor>> GetFloorsAsync()
    {
        return await _ctx.Floors.ToListAsync();
    }

    public async Task<Floor> GetFloorByIdAsync(int id)
    {
        return await _ctx.Floors.FindAsync(id);
    }

    public async Task<Floor> AddFloorAsync(Floor floor)
    {
        _ctx.Floors.Add(floor);
        await _ctx.SaveChangesAsync();
        return floor;
    }

    public async Task<Floor> UpdateFloorAsync(Floor floor)
    {
        _ctx.Entry(floor).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return floor;
    }

    public async Task<Floor> DeleteFloorAsync(int id)
    {
        var floor = await _ctx.Floors.FindAsync(id);
        if (floor == null)
        {
            return null;
        }

        _ctx.Floors.Remove(floor);
        await _ctx.SaveChangesAsync();
        return floor;
    }
}
