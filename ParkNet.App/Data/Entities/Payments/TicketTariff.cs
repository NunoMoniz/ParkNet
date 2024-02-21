namespace ParkNet.App.Data.Entities.Payments;

public class TicketTariff
{
    public int Id { get; set; }
    [Required]
    public double FirstHour15min { get; set; }
    [Required]
    public double SecondAndNextHours { get; set; }
}
