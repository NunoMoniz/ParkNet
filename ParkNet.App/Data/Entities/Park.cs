using System.ComponentModel.DataAnnotations;

namespace ParkNet.App.Data.Entities;

public class Park
{
    [Key]
    public int ParkId { get; set; }
    [Required]
    public string Name { get; set; }
}
