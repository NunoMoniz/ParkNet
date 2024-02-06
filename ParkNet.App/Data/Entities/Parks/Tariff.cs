namespace ParkNet.App.Data.Entities.Parks;

public class Tariff
{
    [Key]
    public int TariffId { get; set; }
    [Required]
    public Park ParkId { get; set; }
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
}
