namespace ParkNet.App.Data;

public class SpaceCreator
{
    private static readonly string[] planUpload = File.ReadAllLines("C:\\Restart10\\teste.txt");
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
    private static Space[,] SpaceInfo()
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
    public static void Print()
    {
        Space[,] space = SpaceInfo();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(space[i, j].Name + " ");
            }
            Console.WriteLine();
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(space[i, j].Type + " ");
            }
            Console.WriteLine();
        }
    }
    private static void UploadSpaces()
    {
        var floorRepo = new FloorRepository(new ApplicationDbContext());
        var spaceRepo = new SpaceRepository(new ApplicationDbContext());
        var floors = floorRepo.GetAllAsync().Result;
        foreach (Floor floor in floors)
        {

        }
        if (c == 'C' || c == 'M')
        {
        }
    }
}
