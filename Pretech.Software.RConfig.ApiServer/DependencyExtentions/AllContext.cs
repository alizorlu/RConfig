using Microsoft.EntityFrameworkCore;
using Pretech.Software.RConfig.Core.Constants;
using Pretech.Software.RConfig.Core.DBContext;

namespace Pretech.Software.RConfig.ApiServer.DependencyExtentions
{
    public static class AllContext
    {
        public static void AddAllContext(this IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG

            ConfigurationBuilder builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile("appsettings.json", true, true).Build();


            var sqlType = (SqlType)Enum.Parse(typeof(SqlType), config["ConnectionStrings:SqlType"].ToString() ?? "Undefined");
            if (sqlType == SqlType.Mysql)
            {
                string cs = config["ConnectionStrings:Mysql"] ?? "";

                services.AddDbContext<RConfigContext>(q => q.UseMySql(cs, ServerVersion.AutoDetect(cs)));

            }
            else if (sqlType == SqlType.MsSQL)
            {
                string cs = config["ConnectionStrings:MsSQL"] ?? "";

                services.AddDbContext<RConfigContext>(q => q.UseSqlServer(cs));

            }
            else if (sqlType == SqlType.Postgresql)
            {
                string cs = config["ConnectionStrings:Postgresql"] ?? "";

                services.AddDbContext<RConfigContext>(q => q.UseNpgsql(cs));
            }
            else
            {
                throw new Exception(nameof(sqlType));
            }

#endif

#if !DEBUG
 var sqlType = (SqlType)Enum.Parse(typeof(SqlType), Environment.GetEnvironmentVariable("SqlType") ?? "Undefined");
            if (sqlType == SqlType.Mysql)
            {
                string cs = Environment.GetEnvironmentVariable("Mysql") ?? "";

                services.AddDbContext<RConfigContext>(q => q.UseMySql(cs, ServerVersion.AutoDetect(cs)));

            }
            else if (sqlType == SqlType.MsSQL)
            {
                string cs = Environment.GetEnvironmentVariable("MsSQL") ?? "";

                services.AddDbContext<RConfigContext>(q => q.UseSqlServer(cs));

            }
            else if (sqlType == SqlType.Postgresql)
            {
                string cs = Environment.GetEnvironmentVariable("Postgresql") ?? "";

                services.AddDbContext<RConfigContext>(q => q.UseNpgsql(cs));
            }
            else
            {
                throw new Exception(nameof(sqlType));
            }

#endif






        }
    }
}
