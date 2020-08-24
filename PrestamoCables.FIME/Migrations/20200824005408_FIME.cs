using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamoCables.FIME.Migrations
{
    public partial class FIME : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FIME");

            migrationBuilder.CreateTable(
                name: "Cables",
                schema: "FIME",
                columns: table => new
                {
                    ID_Cable = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCable = table.Column<string>(maxLength: 50, nullable: false),
                    Longitud = table.Column<int>(nullable: false),
                    Estatus = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cables", x => x.ID_Cable);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                schema: "FIME",
                columns: table => new
                {
                    ID_Prestamo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(nullable: false),
                    ID_Cable = table.Column<int>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    Salon = table.Column<string>(maxLength: 25, nullable: false),
                    Hora = table.Column<string>(maxLength: 2, nullable: false),
                    Materia = table.Column<string>(maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.ID_Prestamo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "FIME",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    TipoCuenta = table.Column<string>(maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_Usuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cables",
                schema: "FIME");

            migrationBuilder.DropTable(
                name: "Prestamos",
                schema: "FIME");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "FIME");
        }
    }
}
