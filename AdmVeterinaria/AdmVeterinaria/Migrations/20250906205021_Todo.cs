using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdmVeterinaria.Migrations
{
    /// <inheritdoc />
    public partial class Todo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duenios",
                columns: table => new
                {
                    IdDuenio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_DUENIO", x => x.IdDuenio);
                });

            migrationBuilder.CreateTable(
                name: "TiposAnimals",
                columns: table => new
                {
                    IdTipoAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipoanimal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_TIPOANIMAL", x => x.IdTipoAnimal);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDuenio = table.Column<int>(type: "int", nullable: true),
                    IdTipoAnimal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ANIMAL", x => x.IdAnimal);
                    table.ForeignKey(
                        name: "FK_Animals_Duenios_IdDuenio",
                        column: x => x.IdDuenio,
                        principalTable: "Duenios",
                        principalColumn: "IdDuenio");
                    table.ForeignKey(
                        name: "FK_Animals_TiposAnimals_IdTipoAnimal",
                        column: x => x.IdTipoAnimal,
                        principalTable: "TiposAnimals",
                        principalColumn: "IdTipoAnimal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atencions",
                columns: table => new
                {
                    IdAtencion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAtencion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TratamientoRebicido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ATENCION", x => x.IdAtencion);
                    table.ForeignKey(
                        name: "FK_Atencions_Animals_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    IdMedicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtencionIdAtencion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_MEDICAMENTO", x => x.IdMedicamento);
                    table.ForeignKey(
                        name: "FK_Medicamentos_Atencions_AtencionIdAtencion",
                        column: x => x.AtencionIdAtencion,
                        principalTable: "Atencions",
                        principalColumn: "IdAtencion");
                });

            migrationBuilder.CreateTable(
                name: "AnimalMedicamento",
                columns: table => new
                {
                    AnimalesIdAnimal = table.Column<int>(type: "int", nullable: false),
                    MedicamentosIdMedicamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalMedicamento", x => new { x.AnimalesIdAnimal, x.MedicamentosIdMedicamento });
                    table.ForeignKey(
                        name: "FK_AnimalMedicamento_Animals_AnimalesIdAnimal",
                        column: x => x.AnimalesIdAnimal,
                        principalTable: "Animals",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalMedicamento_Medicamentos_MedicamentosIdMedicamento",
                        column: x => x.MedicamentosIdMedicamento,
                        principalTable: "Medicamentos",
                        principalColumn: "IdMedicamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalMedicamento_MedicamentosIdMedicamento",
                table: "AnimalMedicamento",
                column: "MedicamentosIdMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_IdDuenio",
                table: "Animals",
                column: "IdDuenio");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_IdTipoAnimal",
                table: "Animals",
                column: "IdTipoAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Atencions_IdAnimal",
                table: "Atencions",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_AtencionIdAtencion",
                table: "Medicamentos",
                column: "AtencionIdAtencion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalMedicamento");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Atencions");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Duenios");

            migrationBuilder.DropTable(
                name: "TiposAnimals");
        }
    }
}
