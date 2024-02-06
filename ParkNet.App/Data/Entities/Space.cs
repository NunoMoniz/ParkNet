namespace ParkNet.App.Data.Entities;

public class Space
{
    public int SpaceId { get; set; }
    public string Name { get; set; }
    public Floor FloorId { get; set; }
}
