namespace ParkNet.App.Data;

public class Helper
{
    public static void SetToOccupied(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        space.IsOccupied = true;
    }

    public static void SetToFree(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        space.IsOccupied = false;
    }

    public static bool CheckIfItIsOccupied(ApplicationDbContext context, int spaceId)
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

    public static bool IsTransactionsSumPositive(int vehicleId, double amount)
    {
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
}
