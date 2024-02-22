namespace ParkNet.App.Data;

public class Helper
{
    public static void SetIsOccupied(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        space.IsOccupied = true;
    }

    public static void SetIsNotOccupied(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        space.IsOccupied = false;
    }

    public static bool CheckIfIsOccupied(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        if (space != null && space.IsOccupied == true)
        {
            return true;
        }
        return false;
    }

    public static DateOnly CalculatePermitExpiry(int name, DateOnly PermitAccess)
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
