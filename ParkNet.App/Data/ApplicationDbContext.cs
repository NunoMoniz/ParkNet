namespace ParkNet.App.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Park> Parks { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Space> Spaces { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<Permit> Permits { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
