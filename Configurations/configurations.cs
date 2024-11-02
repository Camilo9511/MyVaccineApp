using Microsoft.EntityFrameworkCore;


namespace GrpcService1.Configurations 
{
    public static class DbConfigurations
    {
        public static IServiceCollection SetDatabaseConfig(this IServiceCollection Services)
        {
            var conecctionString = "Server=localhost,1433;Database=MyVaccineAppDb;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True";
            Services.AddDbContext<MyVaccineAppDbContext>(options =>
                options.UseSqlServer(conecctionString
                )
                );
            return Services;
        }
    }
}

