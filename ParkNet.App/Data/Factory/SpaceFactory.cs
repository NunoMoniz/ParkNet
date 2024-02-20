namespace ParkNet.App.Data.Creators;

public class SpaceFactory
{
    
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
        Space[,] space = new Space[Rows(), MaxCols()];
        for (int i = 0; i < Rows(); i++)
        {
            for (int j = 0; j < MaxCols(); j++)
            {
                space[i, j] = new Space();
                space[i, j].Name = SpaceNominator(i, j);
                space[i, j].FloorId = floorId;
            }
        }
        //for (int i = 0; i < Rows(); i++)
        //{
        //    string line = lines[i];
        //    for (int j = 0; j < Cols(); j++)
        //    {
        //        space[i, j].Type = line[j];
        //    }
        //}
        return space.Cast<Space>().ToList();
    }
}
