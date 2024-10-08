﻿namespace ParkNet.App.Data.Entities.Parks;

public class Park
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<Floor> Floors { get; set; }
}
