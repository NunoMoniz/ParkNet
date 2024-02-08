namespace ParkNet.App.Data.Repositories.PaymentsRep;

public class TicketRepository
{
    private readonly ApplicationDbContext _ctx;

    public TicketRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Ticket>> GetAllAsync() => await _ctx.Tickets.ToListAsync();

    public async Task<Ticket> GetByIdAsync(int id) => await _ctx.Tickets.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Ticket> AddAsync(Ticket ticket)
    {
        _ctx.Tickets.Add(ticket);
        await _ctx.SaveChangesAsync();

        return ticket;
    }
}
