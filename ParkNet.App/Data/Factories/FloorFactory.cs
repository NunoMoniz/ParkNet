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

        // processar o plan e criar os espaços
        // - split em linhas
        string[] lines = floorPlan.Split('\n');

        // - percorrer as linhas
        for (int i = 0; i < lines.Length; i++)
        {
            // - para cada linha, percorrer os caracteres
            for (int j = 0; j < lines[i].Length; j++)
            {
                // - para cada caracter, criar um espaço
                Space space = new()
                {
                    Name = SpaceNominator(i, j),
                    Type = lines[i][j],
                    IsOccupied = false,
                };
                spaces.Add(space);
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
