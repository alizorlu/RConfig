using Pretech.Software.RConfig.Core.Repository.Base;
using Pretech.Software.RConfig.Core.Repository.Projects.Abstract;
using Pretech.Software.RConfig.Core.Repository.Projects.Concrete;
using Pretech.Software.RConfig.Core.Repository.Section.Abstract;
using Pretech.Software.RConfig.Core.Repository.Section.Concrete;
using Pretech.Software.RConfig.Crypto.Abstract;
using Pretech.Software.RConfig.Crypto.Concrete;

namespace Pretech.Software.RConfig.UI.DependencyExtentions
{
    public static class AllDependencyInjections
    {
        public static void AddAllDependencyInjections(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IProjectsRepository, ProjectRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();


            services.AddTransient<IJsonCrypto, JsonCrypto>();
        }
    }
}
