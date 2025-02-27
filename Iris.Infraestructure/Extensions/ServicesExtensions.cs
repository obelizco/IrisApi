using Iris.Domain.Helpers;
using Iris.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Iris.Infraestructure.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ToDoService>();
        services.AddTransient<JWTokenGenerator>();
        return services;
    }
}
