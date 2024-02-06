namespace ParkNet.App.Data.Entities.Payments;

public class Permit
{
    [Key]
    public int PermitId { get; set; }
    [Required]
    public Vehicle VehicleId { get; set; }
    [Required]
    public Park ParkId { get; set; }
    [Required]
    public int Name { get; set; }
    [Required]
    public DateOnly PermitAccess { get; set; }
    [Required]
    public DateOnly PermitExpiry
    {
        get
        {
            return PermitAccess.AddMonths(Name);
        }
    }
}
