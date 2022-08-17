using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MessageBoardClient.Models
{
  public class MessageBoardClientContextFactory : IDesignTimeDbContextFactory<MessageBoardClientContext>
  {

    MessageBoardClientContext IDesignTimeDbContextFactory<MessageBoardClientContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<MessageBoardClientContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new MessageBoardClientContext(builder.Options);
    }
  }
}