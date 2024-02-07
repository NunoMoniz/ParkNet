namespace ParkNet.App.Data.Entities.Parks;

public class Tariff
{
    public int Id { get; set; }
    [Required]
    public double First15min { get; set; }
    [Required]
    public double Second15min { get; set; }
    [Required]
    public double Third15min { get; set; }
    [Required]
    public double Fourth15min { get; set; }
    [Required]
    public double SecondAndNextHours { get; set; }
    public int ParkId { get; set; }
    public Park Park { get; set; }
}
