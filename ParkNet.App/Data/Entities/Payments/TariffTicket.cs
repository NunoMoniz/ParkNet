namespace ParkNet.App.Data.Entities.Payments;

public class TariffTicket
{
    public int Id { get; set; }
    [Required]
    public double FirstHour15min { get; set; }
    [Required]
    public double SecondAndNextHours { get; set; }
}
