namespace ParkNet.App.Data.Entities.Users;

public class Document
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]

    public int Number { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
