namespace ParkNet.App.Data.Entities.Payments;

public class Permit
{
    public int Id { get; set; }
    [Required]
    public int Months { get; set; }
    [Required]
    public DateTime PermitAccess { get; set; }
    [Required]
    public DateTime PermitExpiry { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int SpaceId { get; set; }
    public Space Space { get; set; }
}
