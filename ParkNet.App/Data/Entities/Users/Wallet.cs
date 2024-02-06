namespace ParkNet.App.Data.Entities.Users;

public class Wallet
{
    [Key]
    public int WalletId { get; set; }
    [Required]
    public User UserId { get; set; }
    [Required]
    public int Transaction { get; set; }
}
