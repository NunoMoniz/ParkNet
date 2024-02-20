using ParkNet.App.Data.Entities.Parks;

namespace ParkNet.App.Data.Creators;

public class FloorFactory
{
    private void Teste()
    {
        var test = ParkFactory.Floors = new List<string[]>();
    }
    private static int Rows() => floors.Length;
    private static int MaxCols()
    {
        int maxCols = 0;
        foreach (string row in floors)
        {
            if (row.Length > maxCols)
            {
                maxCols = row.Length;
            }
        }
        return maxCols;
    }
}
