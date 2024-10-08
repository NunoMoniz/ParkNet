﻿namespace ParkNet.App.Data.Entities.Users;

public class Vehicle
{
    public int Id { get; set; }
    [Required]
    public string LicensePlate { get; set; }
    [Required]
    public char Type { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
