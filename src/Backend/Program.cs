using Backend;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    // EF Core uses this method at design time to access the DbContext
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return new HostBuilder()
                .ConfigureWebHostDefaults(ConfigureWebHost());

    }

    private static Action<IWebHostBuilder> ConfigureWebHost()
    {
        return webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        };
    }
}