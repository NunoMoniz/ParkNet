﻿using System.Diagnostics.CodeAnalysis;

namespace ParkNet.App.Data.Entities.Parks;

public class Space
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public char Type { get; set; }
    [AllowNull]
    public int FloorId { get; set; }
    public Floor Floor { get; set; }
}
