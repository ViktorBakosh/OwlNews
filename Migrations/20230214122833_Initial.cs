using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OwlNews.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cherkassy1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cherkassy1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chernihiv1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chernihiv1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chernivtsi1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chernivtsi1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dnipropetrovsk1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dnipropetrovsk1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ivano_frankivsk1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ivano_frankivsk1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kharkiv1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kharkiv1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kherson1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kherson1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "khmelnytskyi1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khmelnytskyi1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kirovohradsk1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kirovohradsk1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kryvyi_rih1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kryvyi_rih1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kyiv1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kyiv1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "luhansk1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luhansk1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lviv1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lviv1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mykolayiv1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mykolayiv1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "odesa1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odesa1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "poltava1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poltava1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rivne1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rivne1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sumy1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sumy1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ternopil1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ternopil1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vinnytsia1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vinnytsia1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "volyn1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volyn1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zakarpattia1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zakarpattia1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zaporizhzhia1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zaporizhzhia1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zhytomyr1",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zhytomyr1", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cherkassy1");

            migrationBuilder.DropTable(
                name: "chernihiv1");

            migrationBuilder.DropTable(
                name: "chernivtsi1");

            migrationBuilder.DropTable(
                name: "dnipropetrovsk1");

            migrationBuilder.DropTable(
                name: "ivano_frankivsk1");

            migrationBuilder.DropTable(
                name: "kharkiv1");

            migrationBuilder.DropTable(
                name: "kherson1");

            migrationBuilder.DropTable(
                name: "khmelnytskyi1");

            migrationBuilder.DropTable(
                name: "kirovohradsk1");

            migrationBuilder.DropTable(
                name: "kryvyi_rih1");

            migrationBuilder.DropTable(
                name: "kyiv1");

            migrationBuilder.DropTable(
                name: "luhansk1");

            migrationBuilder.DropTable(
                name: "lviv1");

            migrationBuilder.DropTable(
                name: "mykolayiv1");

            migrationBuilder.DropTable(
                name: "odesa1");

            migrationBuilder.DropTable(
                name: "poltava1");

            migrationBuilder.DropTable(
                name: "rivne1");

            migrationBuilder.DropTable(
                name: "sumy1");

            migrationBuilder.DropTable(
                name: "ternopil1");

            migrationBuilder.DropTable(
                name: "vinnytsia1");

            migrationBuilder.DropTable(
                name: "volyn1");

            migrationBuilder.DropTable(
                name: "zakarpattia1");

            migrationBuilder.DropTable(
                name: "zaporizhzhia1");

            migrationBuilder.DropTable(
                name: "zhytomyr1");
        }
    }
}
