namespace ParkNet.App.Data.Entities;

public class Floor
{
    public int FloorId { get; set; }
    public string Name { get; set; }
    public Park ParkId { get; set; }
}
