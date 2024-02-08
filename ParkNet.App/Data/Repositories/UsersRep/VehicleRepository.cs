namespace ParkNet.App.Data.Repositories.UsersRep;

public class VehicleRepository
{
    private readonly ApplicationDbContext _ctx;

    public VehicleRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Vehicle>> GetAllAsync() => await _ctx.Vehicles.ToListAsync();
    public async Task<Vehicle> GetByIdAsync(int id) => await _ctx.Vehicles.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Vehicle> AddAsync(Vehicle vehicle)
    {
        _ctx.Vehicles.Add(vehicle);
        await _ctx.SaveChangesAsync();

        return vehicle;
    }
    

    public async Task UpdateAsync(Vehicle vehicle)
    {
        _ctx.Attach(vehicle).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }
}
