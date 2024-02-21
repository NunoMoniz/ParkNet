using System.Diagnostics.CodeAnalysis;

namespace ParkNet.App.Data.Entities.Parks;

public class Floor
{
    public int Id { get; set; }
    [Required]
    public int Number { get; set; }
    [AllowNull]
    public int ParkId { get; set; }
    public Park Park { get; set; }
    public ICollection<Space> Spaces { get; set; }
}
