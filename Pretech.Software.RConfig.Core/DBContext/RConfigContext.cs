using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pretech.Software.RConfig.Core.Constants;
using Pretech.Software.RConfig.Core.DBContext.Tables;

namespace Pretech.Software.RConfig.Core.DBContext
{
    public class RConfigContext : DbContext
    {
        public DbSet<TBL_Projects> Projects { get; set; }
        public DbSet<TBL_Sections> Sections { get; set; }
        public RConfigContext()
        {
            
        }
        public RConfigContext(DbContextOptions<RConfigContext> options) : base(options)
        {



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

#if DEBUG

                ConfigurationBuilder builder = new ConfigurationBuilder();
                var config = builder.AddJsonFile("appsettings.json", true, true).Build();

                var sqlType = (SqlType)Enum.Parse(typeof(SqlType), config["ConnectionStrings:SqlType"].ToString() ?? "Undefined");
                if (sqlType == SqlType.Mysql)
                {
                    string cs = config["ConnectionStrings:Mysql"] ?? "";
                    optionsBuilder.UseMySql(cs, ServerVersion.AutoDetect(cs));
                }
                else if (sqlType == SqlType.MsSQL)
                {
                    string cs = config["ConnectionStrings:MsSQL"] ?? "";
                    optionsBuilder.UseSqlServer(cs);
                }
                else if (sqlType == SqlType.Postgresql)
                {
                    string cs = config["ConnectionStrings:Postgresql"] ?? ""; optionsBuilder.UseNpgsql(cs);
                }
                else
                {
                    throw new Exception("error --->>>" + nameof(sqlType));
                }


#endif
#if !DEBUG
 var sqlType = (SqlType)Enum.Parse(typeof(SqlType), Environment.GetEnvironmentVariable("SqlType") ?? "Undefined");
                if (sqlType == SqlType.Mysql)
                {
                    string cs = Environment.GetEnvironmentVariable("Mysql") ?? "";
                    optionsBuilder.UseMySql(cs, ServerVersion.AutoDetect(cs));
                }
                else if (sqlType == SqlType.MsSQL)
                {
                    string cs = Environment.GetEnvironmentVariable("MsSQL") ?? "";
                    optionsBuilder.UseSqlServer(cs);
                }
                else if (sqlType == SqlType.Postgresql)
                {
                    string cs = Environment.GetEnvironmentVariable("Postgresql") ?? "";
                    optionsBuilder.UseNpgsql(cs);
                }
                else
                {
                    throw new Exception("error --->>>" + nameof(sqlType));
                }
#endif




            }
        }

    }
}
