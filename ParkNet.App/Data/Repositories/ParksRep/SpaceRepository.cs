namespace ParkNet.App.Data.Repositories.ParksRep;

public class SpaceRepository
{
    private readonly ApplicationDbContext _ctx;

    public SpaceRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Space>> GetAllAsync() => await _ctx.Spaces.ToListAsync();
    public async Task<Space> GetByIdAsync(int id) => await _ctx.Spaces.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Space> AddAsync(Space space)
    {
        _ctx.Spaces.Add(space);
        await _ctx.SaveChangesAsync();

        return space;
    }
}
