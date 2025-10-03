using CodeMazeCQRSGuide.Constants;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace CodeMazeCQRSGuide.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConfigurationConstants.DefaultConnectionStringParameterName);

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException($"Connection string '{ConfigurationConstants.DefaultConnectionStringParameterName}' not found.");
        }
        
        return services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
    }
}
