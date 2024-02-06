namespace ParkNet.App.Data.Entities.Users;

public class Vehicle
{
    [Key]
    public int VehicleId { get; set; }
    [Required]
    public User UserId { get; set; }
    [Required]
    public string LicensePlate { get; set; }
    [Required]
    public char Type { get; set; }
}
