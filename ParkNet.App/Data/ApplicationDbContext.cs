namespace ParkNet.App.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Park> Parks { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Space> Spaces { get; set; }
    public DbSet<Permit> Permits { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TariffPermit> TariffPermits { get; set; }
    public DbSet<TariffTicket> TariffTickets { get; set; }
    public DbSet<Document> Documents { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

//public DbSet<ParkNet.App.Data.Entities.Users.Document> Documents { get; set; }
}
