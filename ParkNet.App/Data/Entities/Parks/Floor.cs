namespace ParkNet.App.Data.Entities.Parks;

public class Floor
{
    [Key]
    public int FloorId { get; set; }
    [Required]
    public Park ParkId { get; set; }
    [Required]
    public int Name { get; set; }
}
