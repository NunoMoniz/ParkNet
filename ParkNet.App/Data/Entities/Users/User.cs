namespace ParkNet.App.Data.Entities.Users;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public int DrivingLicense { get; set; }
    [Required]
    public int BankCard { get; set; }
    /*
        public string Email { get; set; }
        public string Password { get; set; }
    */
}
