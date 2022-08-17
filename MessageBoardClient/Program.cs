using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardClient
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
    //Configures new localhost ports 
    // public static IHostBuilder CreateHostBuilder(string[] args)
    // {
    //   Host.CreateDefaultBuilder(args)
    //       .ConfigureWebHostDefaults(webBuilder => 
    //       {
    //         webBuilder.UseStartUp<Startup>();
    //         webBuilder.UseUrls("http://localhost:5004/");
    //       });
    // }
	}
}