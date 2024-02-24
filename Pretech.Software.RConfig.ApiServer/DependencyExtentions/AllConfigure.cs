using Pretech.Software.RConfig.ApiServer.Query.Config;

namespace Pretech.Software.RConfig.ApiServer.DependencyExtentions
{
    public static class AllConfigure
    {
        public static void AddAllConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(q => q.RegisterServicesFromAssemblies(typeof(QueryConfig).Assembly));
            //services.Configure<Security>(configuration.GetSection(nameof(Security))); 
        }
    }
}
