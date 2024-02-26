namespace ParkNet.App.Data.Entities.Users;

public class Transaction
{
    public int Id { get; set; }
    [Required]
    public double InsAndOuts { get; set; }
    [Required]
    public DateTime Datetime { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
