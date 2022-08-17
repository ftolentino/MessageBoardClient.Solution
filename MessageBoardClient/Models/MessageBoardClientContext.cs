using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MessageBoardClient.Models
{
  public class MessageBoardClientContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Message> Messages { get; set; }

    public MessageBoardClientContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}