namespace ParkNet.App.Data.Repositories.ParksRep;

public class SpaceRepository
{
    private readonly ApplicationDbContext _ctx;

    public SpaceRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public Space Add(Space space)
    {
        _ctx.Spaces.Add(space);
        _ctx.SaveChanges();

        return space;
    }

    public async Task<Space> AddAsync(Space space)
    {
        _ctx.Spaces.Add(space);
        await _ctx.SaveChangesAsync();

        return space;
    }

    public Space Add(string name, char type)
    {
        Space space = new Space
        {
            Name = name,
            Type = type
        };

        _ctx.Spaces.Add(space);
        _ctx.SaveChanges();

        return space;
    }

    public List<Space> GetAll() => _ctx.Spaces.ToList();

    public async Task<List<Space>> GetAllAsync() => await _ctx.Spaces.ToListAsync();


    public void Delete(int id)
    {
        var space = _ctx.Spaces.FirstOrDefault(b => b.Id == id);

        if (space != null)
        {
            _ctx.Spaces.Remove(space);
            _ctx.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var space = await _ctx.Spaces.FirstOrDefaultAsync(b => b.Id == id);

        if (space != null)
        {
            _ctx.Spaces.Remove(space);
            await _ctx.SaveChangesAsync();
        }
    }

    public Space GetById(int id) => _ctx.Spaces.FirstOrDefault(space => space.Id == id);
    public async Task<Space> GetByIdAsync(int id) => await _ctx.Spaces.FirstOrDefaultAsync(space => space.Id == id);

    public void Update(Space space)
    {
        _ctx.Attach(space).State = EntityState.Modified;
        _ctx.SaveChanges();
    }

    public async Task UpdateAsync(Space space)
    {
        _ctx.Attach(space).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

}

