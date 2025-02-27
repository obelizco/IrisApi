
using Iris.Domain.Ports;
using Iris.Infraestructure.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Iris.Infraestructure.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddTransient<IToDoRepository, ToDoRepository>();
        return services;
    }
}
