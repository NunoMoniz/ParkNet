using System.Diagnostics.CodeAnalysis;

namespace ParkNet.App.Data.Entities.Payments;

public class Ticket
{
    public int Id { get; set; }
    [Required]
    public DateTime EntryDateTime { get; set; }
    [AllowNull]
    public DateTime? ExitDateTime { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int SpaceId { get; set; }
    public Space Space { get; set; }
}
