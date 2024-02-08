namespace ParkNet.App.Data;

public class FloorCreator
{
    private static string TxtPath()
    {
        //var txt = uploaded txt by admin;
        return "C:\\Restart10\\teste.txt";
    }
    private static int[,] MatrixCounter()
    {
        string[] readtxt = File.ReadAllLines(TxtPath());
        int rows = readtxt.Length;
        int cols = 0;
        foreach (string line in readtxt)
        {
            if (line.Length > cols)
            {
                cols = line.Length;
            }
        }
        int[,] matrix = new int[rows, cols];
        return matrix;
    }
    private static char[,] Spaces()
    {
        string[] readTxt = File.ReadAllLines(TxtPath());
        int[,] matrix = MatrixCounter();
        char[,] spaces = new char[matrix.GetLength(0), matrix.GetLength(1)];
        int i = 0;
        foreach (string line in readTxt)
        {
            int j = 0;
            foreach (char c in line)
            {
                spaces[i, j] = c;
                j++;
            }
            i++;
        }
        return spaces;
    }
    public static Space SpaceNominator()
    {
        char[,] spaces = Spaces();
        Space space = new();
        Floor floor = new();

        foreach (var space in spaces)
        {
            if (space == "C")
            {

            }
            else if (space == "M")
            {

            }
            else if (space == " ")
            {

            }
            else
            {
                return null;
            }
            return space1;
        }
    }
}
