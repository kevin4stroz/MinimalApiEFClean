namespace Web.Api.Extensions;

public static class CorsExtensions{

    public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
    {
        var corsSettings = configuration.GetSection("Cors");

        var allowedOrigins = corsSettings.GetSection("AllowedOrigins").Get<string[]>() ?? new[] { "*" };
        var allowedHeaders = corsSettings.GetSection("AllowedHeaders").Get<string[]>() ?? new[] { "*" };
        var allowedMethods = corsSettings.GetSection("AllowedMethods").Get<string[]>() ?? new[] { "*" };

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.WithOrigins(allowedOrigins)
                           .WithHeaders(allowedHeaders)
                           .WithMethods(allowedMethods);
                });
        });

        return services;
    }
}