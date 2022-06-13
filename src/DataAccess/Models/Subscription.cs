namespace DataAccess.Models;

public class Subscription
{
    public enum Level
    {
        Basic = 1,
        Standard,
        Premium
    }

    public int Id { get; set; }
    public Level Name { get; set; }
    public decimal PricePerMonth { get; set; }
    public int NumberOfSimultaneousDevices { get; set; }
    public int NumberDevicesWithDownloadCapability { get; set; }

}
