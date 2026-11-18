using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace G_NET_91_EF03.Context
{
    public class OnlineLearningPlatformContextFactory : IDesignTimeDbContextFactory<OnlineLearningPlatformContext>
    {
        public OnlineLearningPlatformContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<OnlineLearningPlatformContext>()
                .UseSqlServer(
                    "Server=.;Database=OnlineLearningPlatformDB;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            return new OnlineLearningPlatformContext(options);
        }
    }
}
