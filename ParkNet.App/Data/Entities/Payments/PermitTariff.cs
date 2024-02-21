namespace ParkNet.App.Data.Entities.Payments;

public class PermitTariff
{
    public int Id { get; set; }
    [Required]
    public double Monthly { get; set; }
    [Required]
    public double Quarterly { get; set; }
    [Required]
    public double Semiannual { get; set; }
    [Required]
    public double Yearly { get; set; }
}
