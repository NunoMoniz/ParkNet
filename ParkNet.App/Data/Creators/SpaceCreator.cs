namespace ParkNet.App.Data.Creators;

public class SpaceCreator
{
    public static string[] planUpload = File.ReadAllLines("C:\\Restart10\\teste2.txt");
    public static readonly int rows = planUpload.Length;
    public static readonly int cols = ColsCounter();
    private static int ColsCounter()
    {
        int cols = 0;
        foreach (string line in planUpload)
        {
            if (line.Length > cols)
            {
                cols = line.Length;
            }
        }
        return cols;
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

    public static List<Space> SpaceInfo(int floorId)
    {
        Space[,] space = new Space[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                space[i, j] = new Space();
                space[i, j].Name = SpaceNominator(i, j);
                space[i, j].FloorId = floorId;
            }
        }
        //for (int i = 0; i < rows; i++)
        //{
        //    string line = planUpload[i];
        //    for (int j = 0; j < cols; j++)
        //    {
        //        space[i, j].Type = line[j];
        //    }
        //}
        return space.Cast<Space>().ToList();
    }
}
