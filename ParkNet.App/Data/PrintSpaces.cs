namespace ParkNet.App.Data;

public class PrintSpaces
{
    public static string[] PrintAllSpaces(ApplicationDbContext context, int floorId)
    {
        var spaces = context.Spaces.Where(s => s.FloorId == floorId).ToList();
        string[] spaceNames = new string[spaces.Count];
        for (int i = 0; i < spaces.Count; i++)
        {
            spaceNames[i] = spaces[i].Name;
        }
        return spaceNames;
    }
}
