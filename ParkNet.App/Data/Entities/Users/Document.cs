namespace ParkNet.App.Data.Entities.Users;

public class Document
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]

    public int Number { get; set; }
    [Required]
    public DateTime ExpirationDate { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
