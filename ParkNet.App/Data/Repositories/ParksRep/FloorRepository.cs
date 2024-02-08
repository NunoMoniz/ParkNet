namespace ParkNet.App.Data.Repositories.ParksRep;

public class FloorRepository
{
    private readonly ApplicationDbContext _ctx;

    public FloorRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Floor>> GetAllAsync() => await _ctx.Floors.ToListAsync();

    public async Task<Floor> GetByIdAsync(int id) => await _ctx.Floors.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Floor> AddAsync(Floor floor)
    {
        _ctx.Floors.Add(floor);
        await _ctx.SaveChangesAsync();

        return floor;
    }
}
