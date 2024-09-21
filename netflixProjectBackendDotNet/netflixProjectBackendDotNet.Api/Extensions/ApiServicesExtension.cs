using netflixProjectBackendDotNet.IoC;

namespace netflixProjectBackendDotNet.Api.Extensions;

public static class ApiServicesExtension
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration) =>
        services
        .SetProjectsConfig(configuration)
        .AddHealthCheck(configuration);

    private static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        return services
            .AddHealthChecks()
            .AddNpgSql(connectionString)
            .Services;
    }
}
