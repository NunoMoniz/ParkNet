namespace ParkNet.App.Data.Repositories.UsersRep;

public class VehicleRepository
{
    private readonly ApplicationDbContext _ctx;

    public VehicleRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
    {
        return await _ctx.Vehicles.ToListAsync();
    }

    public async Task<Vehicle> GetVehicleByIdAsync(int id)
    {
        return await _ctx.Vehicles.FindAsync(id);
    }

    public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
    {
        _ctx.Vehicles.Add(vehicle);
        await _ctx.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
    {
        _ctx.Entry(vehicle).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle> DeleteVehicleAsync(int id)
    {
        var vehicle = await _ctx.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return null;
        }

        _ctx.Vehicles.Remove(vehicle);
        await _ctx.SaveChangesAsync();
        return vehicle;
    }
}
