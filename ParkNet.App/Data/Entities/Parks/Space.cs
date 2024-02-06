namespace ParkNet.App.Data.Entities.Parks;

public class Space
{
    [Key]
    public int SpaceId { get; set; }
    [Required]
    public Floor FloorId { get; set; }
    [Required]
    public string Name { get; set; }
}
