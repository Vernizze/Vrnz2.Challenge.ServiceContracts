using Microsoft.Extensions.DependencyInjection;

namespace Vrnz2.Challenge.ServiceContracts.Settings
{
    public static class AppSettingsServiceExtensions
    {
        public static IServiceCollection AddSettings<T>(this IServiceCollection services, string jsonAttributeName)
            where T : BaseAppSettings
            => services
                .Configure<T>(ConfigurationFactory.Instance.Configuration.GetSection(jsonAttributeName));

        public static IServiceCollection AddSettings<T>(this IServiceCollection services)
            where T : BaseAppSettings
            => services
                .Configure<T>(ConfigurationFactory.Instance.Configuration);
    }
}
