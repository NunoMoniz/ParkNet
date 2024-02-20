namespace ParkNet.App.Data.Creators;

public class ParkFactory
{
    public static List<string[]> floors = new List<string[]>();
    public static void Plan(string input)
    {
        string[] lines = input.Split("\n");

        List<string> currentFloor = new List<string>();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                floors.Add(currentFloor.ToArray());
                currentFloor.Clear();
            }
            else
            {
                currentFloor.Add(line);
            }
        }
    }
}
