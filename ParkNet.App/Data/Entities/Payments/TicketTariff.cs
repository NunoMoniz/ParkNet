namespace ParkNet.App.Data.Entities.Payments;

public class TicketTariff
{
    public int Id { get; set; }
    [Required]
    public double Each15minOnFirstHour { get; set; }
    [Required]
    public double SecondAndNextHours { get; set; }
}
