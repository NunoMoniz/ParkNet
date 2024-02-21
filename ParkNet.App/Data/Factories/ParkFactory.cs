namespace ParkNet.App.Data.Factories;

class ParkFactory
{
    public static Park CreatePark(string name, string plan)
    {
        string[] floorPlans = CreateFloorPlans(plan);       
        List<Floor> floors = CreateFloors(floorPlans);

        Park park = new()
        {
            Name = name,
            Floors = floors
        };
        return park;
    }

    private static string[] CreateFloorPlans(string plan)
    {
        return plan.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }
 
    private static List<Floor> CreateFloors(string[] floorPlans)
    {
        List<Floor> floors = [];
        for(int i = 0; i < floorPlans.Length; i++)
        {
            floors.Add(FloorFactory.CreateFloor(floorPlans[i], i));
        }
        return floors;
    }
}
