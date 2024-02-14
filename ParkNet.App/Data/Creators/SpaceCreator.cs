namespace ParkNet.App.Data.Creators;

public class SpaceCreator
{
    public static string[] planUpload;
    //public static string[] GetPlanUpload() { return planUpload; }
    private static readonly int rows = planUpload.Length;
    private static readonly int cols = MatrixCounter();
    private static int MatrixCounter()
    {
        string[] lines = planUpload;
        int cols = 0;
        foreach (string line in lines)
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
    public static Space[,] SpaceInfo()
    {
        string[] plan = planUpload;
        Space[,] space = new Space[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                space[i, j] = new Space();
                space[i, j].Name = SpaceNominator(i, j);
            }
        }
        for (int i = 0; i < plan.Length; i++)
        {
            string line = plan[i];
            for (int j = 0; j < line.Length; j++)
            {
                space[i, j].Type = line[j];
            }
        }
        return space;
    }

    //private static void UploadSpaces()
    //{
    //    var spaceRepo = new SpaceRepository(new ApplicationDbContext());
    //    if (c == 'C' || c == 'M')
    //    {
    //    }
    //}
}
