namespace ParkNet.App.Data.Repositories.ParksRep;

public class ParkRepository
{
    private readonly ApplicationDbContext _ctx;

    public ParkRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Park>> GetAllAsync() => await _ctx.Parks.ToListAsync();

    public async Task<Park> GetByIdAsync(int id) => await _ctx.Parks.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Park> AddAsync(Park park)
    {
        _ctx.Parks.Add(park);
        await _ctx.SaveChangesAsync();

        return park;
    }




}
