namespace ParkNet.App.Data.Entities.Payments;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    [Required]
    public Vehicle VehicleId { get; set; }
    [Required]
    public DateTime EntryDateTime { get; set; }
    [Required]
    public DateTime ExitDateTime { get; set; }
}
