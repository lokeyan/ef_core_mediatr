namespace DataAccess.Models;

public class Subscription
{
    public enum Level
    {
        Basic = 1,
        Standard,
        Premium
    }

    public Level Id { get; set; }
    public string Name { get; set; }
    public decimal PricePerMonth { get; set; }
    public int NumberOfSimultaneousDevices { get; set; }
    public int NumberDevicesWithDownloadCapability { get; set; }

}
