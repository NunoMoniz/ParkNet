namespace ParkNet.App.Data.Repositories.ParksRep;

public class TariffRepository
{
    private readonly ApplicationDbContext _ctx;

    public TariffRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Tariff>> GetTariffsAsync()
    {
        return await _ctx.Tariffs.ToListAsync();
    }

    public async Task<Tariff> GetTariffByIdAsync(int id)
    {
        return await _ctx.Tariffs.FindAsync(id);
    }

    public async Task<Tariff> AddTariffAsync(Tariff tariff)
    {
        _ctx.Tariffs.Add(tariff);
        await _ctx.SaveChangesAsync();
        return tariff;
    }

    public async Task<Tariff> UpdateTariffAsync(Tariff tariff)
    {
        _ctx.Entry(tariff).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return tariff;
    }

    public async Task<Tariff> DeleteTariffAsync(int id)
    {
        var tariff = await _ctx.Tariffs.FindAsync(id);
        if (tariff == null)
        {
            return null;
        }

        _ctx.Tariffs.Remove(tariff);
        await _ctx.SaveChangesAsync();
        return tariff;
    }
}
