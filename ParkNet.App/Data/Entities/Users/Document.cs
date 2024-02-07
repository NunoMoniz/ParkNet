namespace ParkNet.App.Data.Entities.Users;

public class Document
{
    public int Id { get; set; }
    [Required]
    public int DrivingLicense { get; set; }
    [Required]
    public int BankCard { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
