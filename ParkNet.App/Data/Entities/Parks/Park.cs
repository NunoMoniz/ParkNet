namespace ParkNet.App.Data.Entities.Parks;

public class Park
{
    [Key]
    public int ParkId { get; set; }
    [Required]
    public string Name { get; set; }
}
