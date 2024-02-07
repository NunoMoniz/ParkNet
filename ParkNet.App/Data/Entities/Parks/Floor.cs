namespace ParkNet.App.Data.Entities.Parks;

public class Floor
{
    public int Id { get; set; }
    [Required]
    public int Name { get; set; }
    public int ParkId { get; set; }
    public Park Park { get; set; }
}
