namespace ParkNet.App.Data.Factories;

public class FloorFactory
{
    public static Floor CreateFloor(string floorPlan, int number)
    {
        List<Space> spaces = CreateSpaces(floorPlan);

        Floor floor = new()
        {
            Number = number,
            Spaces = spaces,
        };

        return floor;
    }

    private static List<Space> CreateSpaces(string floorPlan)
    {
        List<Space> spaces = [];

        string[] lines = floorPlan.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (lines[i][j] == ' ')
                {
                    Space space = new()
                    {
                        Name = SpaceNominator(i, j),
                        Type = lines[i][j],
                        IsOccupied = true
                    };
                    spaces.Add(space);
                }
                else if (lines[i][j] != ' ')
                {
                    Space space = new()
                    {
                        Name = SpaceNominator(i, j),
                        Type = lines[i][j],
                        IsOccupied = false
                    };
                    spaces.Add(space);
                }

            }
        }
        return spaces;
    }

    private static string SpaceNominator(int row, int col)
    {
        string letter = "";
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < letters.Length; i++)
        {
            if (row == i)
            {
                letter = letters[i].ToString();
                break;
            }
        }
        return $"{letter}{col + 1}";
    }
}
