namespace ParkNet.App.Data.Repositories.PaymentsRep;

public class TicketRepository
{
    private readonly ApplicationDbContext _ctx;

    public TicketRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Ticket>> GetTicketsAsync()
    {
        return await _ctx.Tickets.ToListAsync();
    }

    public async Task<Ticket> GetTicketByIdAsync(int id)
    {
        return await _ctx.Tickets.FindAsync(id);
    }

    public async Task<Ticket> AddTicketAsync(Ticket ticket)
    {
        _ctx.Tickets.Add(ticket);
        await _ctx.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> UpdateTicketAsync(Ticket ticket)
    {
        _ctx.Entry(ticket).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> DeleteTicketAsync(int id)
    {
        var ticket = await _ctx.Tickets.FindAsync(id);
        if (ticket == null)
        {
            return null;
        }

        _ctx.Tickets.Remove(ticket);
        await _ctx.SaveChangesAsync();
        return ticket;
    }
}
