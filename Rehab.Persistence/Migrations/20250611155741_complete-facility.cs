using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rehab.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class completefacility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Accreditations_AccreditationId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Amenities_AmenityId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Highlights_HighlightId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Locs_LocId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Treatments_TreatmentId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Wwts_WwtId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_AccreditationId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_AmenityId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_HighlightId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_LocId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_TreatmentId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_WwtId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "AccreditationId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "AmenityId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "HighlightId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "LocId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "WhoWeTreat",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "WwtId",
                table: "Facilities");

            migrationBuilder.RenameColumn(
                name: "Occupancy",
                table: "Facilities",
                newName: "Slug");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "OccupancyMax",
                table: "Facilities",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "OccupancyMin",
                table: "Facilities",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "ProvidersPolicy",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AccreditationFacility",
                columns: table => new
                {
                    AccreditationsId = table.Column<int>(type: "int", nullable: false),
                    FacilitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccreditationFacility", x => new { x.AccreditationsId, x.FacilitiesId });
                    table.ForeignKey(
                        name: "FK_AccreditationFacility_Accreditations_AccreditationsId",
                        column: x => x.AccreditationsId,
                        principalTable: "Accreditations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccreditationFacility_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmenityFacility",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "int", nullable: false),
                    FacilitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityFacility", x => new { x.AmenitiesId, x.FacilitiesId });
                    table.ForeignKey(
                        name: "FK_AmenityFacility_Amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityFacility_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilityHighlight",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(type: "int", nullable: false),
                    HighlightsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityHighlight", x => new { x.FacilitiesId, x.HighlightsId });
                    table.ForeignKey(
                        name: "FK_FacilityHighlight_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityHighlight_Highlights_HighlightsId",
                        column: x => x.HighlightsId,
                        principalTable: "Highlights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilityLoc",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(type: "int", nullable: false),
                    LocsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityLoc", x => new { x.FacilitiesId, x.LocsId });
                    table.ForeignKey(
                        name: "FK_FacilityLoc_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityLoc_Locs_LocsId",
                        column: x => x.LocsId,
                        principalTable: "Locs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilitysImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitysImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitysImages_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacilityTreatment",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(type: "int", nullable: false),
                    TreatmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTreatment", x => new { x.FacilitiesId, x.TreatmentsId });
                    table.ForeignKey(
                        name: "FK_FacilityTreatment_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityTreatment_Treatments_TreatmentsId",
                        column: x => x.TreatmentsId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilityWwt",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(type: "int", nullable: false),
                    WwtsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityWwt", x => new { x.FacilitiesId, x.WwtsId });
                    table.ForeignKey(
                        name: "FK_FacilityWwt_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityWwt_Wwts_WwtsId",
                        column: x => x.WwtsId,
                        principalTable: "Wwts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccreditationFacility_FacilitiesId",
                table: "AccreditationFacility",
                column: "FacilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenityFacility_FacilitiesId",
                table: "AmenityFacility",
                column: "FacilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityHighlight_HighlightsId",
                table: "FacilityHighlight",
                column: "HighlightsId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityLoc_LocsId",
                table: "FacilityLoc",
                column: "LocsId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitysImages_FacilityId",
                table: "FacilitysImages",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityTreatment_TreatmentsId",
                table: "FacilityTreatment",
                column: "TreatmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityWwt_WwtsId",
                table: "FacilityWwt",
                column: "WwtsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccreditationFacility");

            migrationBuilder.DropTable(
                name: "AmenityFacility");

            migrationBuilder.DropTable(
                name: "FacilityHighlight");

            migrationBuilder.DropTable(
                name: "FacilityLoc");

            migrationBuilder.DropTable(
                name: "FacilitysImages");

            migrationBuilder.DropTable(
                name: "FacilityTreatment");

            migrationBuilder.DropTable(
                name: "FacilityWwt");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "OccupancyMax",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "OccupancyMin",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "ProvidersPolicy",
                table: "Facilities");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Facilities",
                newName: "Occupancy");

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

            migrationBuilder.AddColumn<short>(
                name: "WhoWeTreat",
                table: "Facilities",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WwtId",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_AccreditationId",
                table: "Facilities",
                column: "AccreditationId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_AmenityId",
                table: "Facilities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_HighlightId",
                table: "Facilities",
                column: "HighlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_LocId",
                table: "Facilities",
                column: "LocId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_TreatmentId",
                table: "Facilities",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_WwtId",
                table: "Facilities",
                column: "WwtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Accreditations_AccreditationId",
                table: "Facilities",
                column: "AccreditationId",
                principalTable: "Accreditations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Amenities_AmenityId",
                table: "Facilities",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Highlights_HighlightId",
                table: "Facilities",
                column: "HighlightId",
                principalTable: "Highlights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Locs_LocId",
                table: "Facilities",
                column: "LocId",
                principalTable: "Locs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Treatments_TreatmentId",
                table: "Facilities",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Wwts_WwtId",
                table: "Facilities",
                column: "WwtId",
                principalTable: "Wwts",
                principalColumn: "Id");
        }
    }
}
