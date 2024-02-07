namespace ParkNet.App.Data.Repositories.ParksRep;

public class SpaceRepository
{
    private readonly ApplicationDbContext _ctx;

    public SpaceRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Space>> GetSpacesAsync()
    {
        return await _ctx.Spaces.ToListAsync();
    }

    public async Task<Space> GetSpaceByIdAsync(int id)
    {
        return await _ctx.Spaces.FindAsync(id);
    }

    public async Task<Space> AddSpaceAsync(Space space)
    {
        _ctx.Spaces.Add(space);
        await _ctx.SaveChangesAsync();
        return space;
    }

    public async Task<Space> UpdateSpaceAsync(Space space)
    {
        _ctx.Entry(space).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return space;
    }

    public async Task<Space> DeleteSpaceAsync(int id)
    {
        var space = await _ctx.Spaces.FindAsync(id);
        if (space == null)
        {
            return null;
        }

        _ctx.Spaces.Remove(space);
        await _ctx.SaveChangesAsync();
        return space;
    }
}
