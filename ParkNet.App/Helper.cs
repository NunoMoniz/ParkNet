using ParkNet.App.Data.Entities.Parks;
using ParkNet.App.Data.Entities.Users;

namespace ParkNet.App;

public class Helper
{
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

    public static bool IsItOccupied(ApplicationDbContext context, int spaceId)
    {
        Space space = context.Spaces.Find(spaceId);
        if (space != null && space.IsOccupied == true)
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

    public static IQueryable<Space> AvailableSpaces(ApplicationDbContext context)
    {
        var availableSpaces = context.Spaces
            .Where(s => s.IsOccupied == false && s.Type == 'C' || s.IsOccupied == false && s.Type == 'M');
        return availableSpaces;
    }

    public static IQueryable<Vehicle> AvailableVehicles(ApplicationDbContext context)
    {
        var availableVehicles = context.Vehicles
            .Where(v => !context.Tickets.Any(t => t.VehicleId == v.Id && t.ExitDateTime == null));

        return availableVehicles;
    }

    public static bool AreDocumentsUpToDate(ApplicationDbContext context, string UserId)
    {
        var documents = context.Documents.Where(d => d.UserId == UserId);

        if (documents.Any(d => d.ExpiryDate < DateTime.Now))
        {
            return false;
        }
        return true;
    }

    public static string GetVehicleLicensePlate(ApplicationDbContext context, int vehicleId)
    {
        Vehicle vehicle = context.Vehicles.Find(vehicleId);
        return vehicle.LicensePlate;
    }

    public static DateTime CalculatePermitExpiry(int name, DateTime PermitAccess)
    {
        return PermitAccess.AddMonths(name);
    }

    public static bool IsBalanceEnough(ApplicationDbContext context, int vehicleId)
    {
        string UserId = context.Vehicles.Find(vehicleId).UserId;
        var transactions = context.Transactions.Where(t => t.UserId == UserId);
        double amount = transactions.Sum(t => t.InsAndOuts);

        if (amount > 0)
        {
            return true;
        }
        return false;
    }

    public static Transaction TicketPaymentCalculator(ApplicationDbContext context, int vehicleId, DateTime entryDateTime, DateTime? exitDateTime)
    {
        TicketTariff tariff = context.TicketsTariff.FirstOrDefault();

        TimeSpan timespan = exitDateTime.Value - entryDateTime;
        double timespanInMinutes = timespan.TotalMinutes;
        double amountOfMinutesExcluding1stHour = timespanInMinutes - 59;
        int blocksOf15minOnFirstHour = 0;
        int amountOfHoursExcluding1stHour = 0;

        if (timespanInMinutes < 60)
        {
            blocksOf15minOnFirstHour = (int)Math.Ceiling((double)timespanInMinutes / 15);
        }
        else if (timespanInMinutes >= 60)
        {
            blocksOf15minOnFirstHour = 4;
            amountOfHoursExcluding1stHour = (int)Math.Ceiling((double)amountOfMinutesExcluding1stHour / 60);
        }

        double each15minTariffOnFirstHour = tariff.Each15minOnFirstHour;
        double each2ndAndNextHoursTariffFrom = tariff.SecondAndNextHours;

        double total = blocksOf15minOnFirstHour * each15minTariffOnFirstHour + amountOfHoursExcluding1stHour * each2ndAndNextHoursTariffFrom;
        double negative = total * -1;

        var transaction = new Transaction
        {
            InsAndOuts = negative,
            UserId = context.Vehicles.Find(vehicleId).UserId,
            Datetime = DateTime.Now,
        };

        return transaction;
    }

    public static Transaction PermitPaymentCalculator(ApplicationDbContext context, int vehicleId, int months)
    {
        PermitTariff tariff = context.PermitsTariff.FirstOrDefault();

        var transaction = new Transaction
        {
            InsAndOuts = 0,
            UserId = context.Vehicles.Find(vehicleId).UserId,
            Datetime = DateTime.Now,
        };

        switch (months)
        {
            case 1:
                transaction.InsAndOuts = tariff.Monthly * -1;
                break;
            case 3:
                transaction.InsAndOuts = tariff.Quarterly * -1;
                break;
            case 6:
                transaction.InsAndOuts = tariff.Semiannual * -1;
                break;
            case 12:
                transaction.InsAndOuts = tariff.Yearly * -1;
                break;
            default:
                break;
        }
        return transaction;
    }
}
