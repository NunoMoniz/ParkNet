namespace ParkNet.App.Data;

public class Helper
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public static void SetToOccupied(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        space.IsOccupied = true;
    }

    public static void SetToAvailable(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        space.IsOccupied = false;
    }

    public static bool OccupiedTrueOrFalse(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        if (space != null && space.IsOccupied == true)
        {
            return true;
        }
        return false;
    }

    public static DateTime CalculatePermitExpiry(int name, DateTime PermitAccess)
    {
        return PermitAccess.AddMonths(name);
    }

    public static bool IsTransactionsSumPositive(int userId, double amount)
    {

        // veículo - usuário - transação
        // get all transactions for the user
        // sum the amounts
        // return true if the sum is positive

        // 

        if (amount > 0)
        {
            return true;
        }
        return false;
    }

    public static string GetSpaceName(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        return space.Name;
    }

    public static string GetVehicleLicensePlate(ApplicationDbContext context, int vehicleId)
    {
        Vehicle vehicle = context.Vehicles.Find(vehicleId);
        return vehicle.LicensePlate;
    }

    public static void AddTransaction(ApplicationDbContext context, int vehicleId, DateTime entryDateTime, DateTime exitDateTime)
    {
        TimeSpan difference = exitDateTime - entryDateTime;
        double minutesDifference = difference.TotalMinutes;
        double BlocksOf15minOnFirstHour;
        double fromSecondHourOn = minutesDifference - 60;

        if (fromSecondHourOn < 0)
        {
            BlocksOf15minOnFirstHour = (int)Math.Ceiling((double)minutesDifference / 15);
        }
        else if (fromSecondHourOn > 0)
        {
            BlocksOf15minOnFirstHour = 4;
        }


        from v in context.Vehicles
    join t in context.Tickets on v.VehicleId equals t.VehicleId into ticketGroup
    from tg in ticketGroup.DefaultIfEmpty()
    where
    select v;

    }
}
