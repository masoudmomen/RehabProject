using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rehab.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<short>(
            //    name: "WhoWeTreat",
            //    table: "Facilities",
            //    type: "smallint",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccreditationId",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmenityId",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HighlightId",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocId",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WwtId",
                table: "Facilities",
                type: "int",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Accreditations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Accreditations", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Amenities",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Amenities", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Highlights",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Highlights", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Locs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Locs", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Treatments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Treatments", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Wwts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Wwts", x => x.Id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Facilities_AccreditationId",
            //    table: "Facilities",
            //    column: "AccreditationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Facilities_AmenityId",
            //    table: "Facilities",
            //    column: "AmenityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Facilities_HighlightId",
            //    table: "Facilities",
            //    column: "HighlightId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Facilities_LocId",
            //    table: "Facilities",
            //    column: "LocId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Facilities_TreatmentId",
            //    table: "Facilities",
            //    column: "TreatmentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Facilities_WwtId",
            //    table: "Facilities",
            //    column: "WwtId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Facilities_Accreditations_AccreditationId",
            //    table: "Facilities",
            //    column: "AccreditationId",
            //    principalTable: "Accreditations",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Facilities_Amenities_AmenityId",
            //    table: "Facilities",
            //    column: "AmenityId",
            //    principalTable: "Amenities",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Facilities_Highlights_HighlightId",
            //    table: "Facilities",
            //    column: "HighlightId",
            //    principalTable: "Highlights",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Facilities_Locs_LocId",
            //    table: "Facilities",
            //    column: "LocId",
            //    principalTable: "Locs",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Facilities_Treatments_TreatmentId",
            //    table: "Facilities",
            //    column: "TreatmentId",
            //    principalTable: "Treatments",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Facilities_Wwts_WwtId",
            //    table: "Facilities",
            //    column: "WwtId",
            //    principalTable: "Wwts",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
