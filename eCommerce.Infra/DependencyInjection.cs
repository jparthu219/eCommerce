using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infra;
public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection service)
    {
        return service;
    }
}
