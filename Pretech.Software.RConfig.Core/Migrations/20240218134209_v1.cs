using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pretech.Software.RConfig.Core.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.IsMySql())
            {
                #region MySql
                migrationBuilder.AlterDatabase()
                      .Annotation("MySql:CharSet", "utf8mb4");

                migrationBuilder.CreateTable(
                    name: "Projects",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                        Name = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Secret = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Key = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Application = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                        Create = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                        Update = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                        RestrictedList = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4")
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Projects", x => x.Id);
                    })
                    .Annotation("MySql:CharSet", "utf8mb4");

                migrationBuilder.CreateTable(
                    name: "Sections",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                        Name = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Value = table.Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        ProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                        Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                        Create = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Sections", x => x.Id);
                    })
                    .Annotation("MySql:CharSet", "utf8mb4");
                #endregion
            }
            else if (migrationBuilder.IsSqlServer())
            {
                #region SqlServer

                migrationBuilder.CreateTable(
               name: "Projects",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Secret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Application = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Active = table.Column<bool>(type: "bit", nullable: false),
                   Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Update = table.Column<DateTime>(type: "datetime2", nullable: false),
                   RestrictedList = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Projects", x => x.Id);
               });

                migrationBuilder.CreateTable(
                    name: "Sections",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Active = table.Column<bool>(type: "bit", nullable: false),
                        Create = table.Column<DateTime>(type: "datetime2", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Sections", x => x.Id);
                    });

                #endregion
            }
            else if (migrationBuilder.IsSqlite())
            {
                #region Sqlite
                migrationBuilder.CreateTable(
             name: "Projects",
             columns: table => new
             {
                 Id = table.Column<Guid>(type: "TEXT", nullable: false),
                 Name = table.Column<string>(type: "TEXT", nullable: false),
                 Secret = table.Column<string>(type: "TEXT", nullable: false),
                 Key = table.Column<string>(type: "TEXT", nullable: false),
                 Application = table.Column<string>(type: "TEXT", nullable: false),
                 Active = table.Column<bool>(type: "INTEGER", nullable: false),
                 Create = table.Column<DateTime>(type: "TEXT", nullable: false),
                 Update = table.Column<DateTime>(type: "TEXT", nullable: false),
                 RestrictedList = table.Column<string>(type: "TEXT", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Projects", x => x.Id);
             });

                migrationBuilder.CreateTable(
                    name: "Sections",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "TEXT", nullable: false),
                        Name = table.Column<string>(type: "TEXT", nullable: false),
                        Value = table.Column<string>(type: "TEXT", nullable: false),
                        ProjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                        Active = table.Column<bool>(type: "INTEGER", nullable: false),
                        Create = table.Column<DateTime>(type: "TEXT", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Sections", x => x.Id);
                    });
                #endregion
            }
            else if (migrationBuilder.IsNpgsql())
            {
                #region Postgresql

                migrationBuilder.CreateTable(
               name: "Projects",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uuid", nullable: false),
                   Name = table.Column<string>(type: "text", nullable: false),
                   Secret = table.Column<string>(type: "text", nullable: false),
                   Key = table.Column<string>(type: "text", nullable: false),
                   Application = table.Column<string>(type: "text", nullable: false),
                   Active = table.Column<bool>(type: "boolean", nullable: false),
                   Create = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                   Update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                   RestrictedList = table.Column<string>(type: "text", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Projects", x => x.Id);
               });

                migrationBuilder.CreateTable(
                    name: "Sections",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "uuid", nullable: false),
                        Name = table.Column<string>(type: "text", nullable: false),
                        Value = table.Column<string>(type: "text", nullable: false),
                        ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                        Active = table.Column<bool>(type: "boolean", nullable: false),
                        Create = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Sections", x => x.Id);
                    });

                #endregion
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
