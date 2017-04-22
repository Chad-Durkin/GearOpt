using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GearOptimizer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bosses",
                columns: table => new
                {
                    BossId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtkStyle = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Weakness = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bosses", x => x.BossId);
                });

            migrationBuilder.CreateTable(
                name: "Drops",
                columns: table => new
                {
                    DropId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drops", x => x.DropId);
                });

            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    GearId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtkCrush = table.Column<int>(nullable: false),
                    AtkMagic = table.Column<int>(nullable: false),
                    AtkRange = table.Column<int>(nullable: false),
                    AtkSlash = table.Column<int>(nullable: false),
                    AtkStab = table.Column<int>(nullable: false),
                    DefCrush = table.Column<int>(nullable: false),
                    DefMagic = table.Column<int>(nullable: false),
                    DefRange = table.Column<int>(nullable: false),
                    DefSlash = table.Column<int>(nullable: false),
                    DefStab = table.Column<int>(nullable: false),
                    MagicDmg = table.Column<int>(nullable: false),
                    MeleeStr = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Prayer = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    RangeStr = table.Column<int>(nullable: false),
                    Slayer = table.Column<int>(nullable: false),
                    Slot = table.Column<string>(nullable: true),
                    Undead = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.GearId);
                });

            migrationBuilder.CreateTable(
                name: "BossDrops",
                columns: table => new
                {
                    BossId = table.Column<int>(nullable: false),
                    DropId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BossDrops", x => new { x.BossId, x.DropId });
                    table.ForeignKey(
                        name: "FK_BossDrops_Bosses_BossId",
                        column: x => x.BossId,
                        principalTable: "Bosses",
                        principalColumn: "BossId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BossDrops_Drops_DropId",
                        column: x => x.DropId,
                        principalTable: "Drops",
                        principalColumn: "DropId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullSets",
                columns: table => new
                {
                    SetType = table.Column<string>(nullable: false),
                    ArrowSlotId = table.Column<int>(nullable: false),
                    BootsId = table.Column<int>(nullable: false),
                    BossId = table.Column<int>(nullable: false),
                    CapeId = table.Column<int>(nullable: false),
                    ChestSlotId = table.Column<int>(nullable: false),
                    FullSetId = table.Column<int>(nullable: false),
                    GearId = table.Column<int>(nullable: true),
                    GlovesId = table.Column<int>(nullable: false),
                    HeadSlotId = table.Column<int>(nullable: false),
                    LegSlotId = table.Column<int>(nullable: false),
                    MainHandId = table.Column<int>(nullable: false),
                    NecklaceId = table.Column<int>(nullable: false),
                    OffHandId = table.Column<int>(nullable: false),
                    RingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullSets", x => x.SetType);
                    table.ForeignKey(
                        name: "FK_FullSets_Bosses_BossId",
                        column: x => x.BossId,
                        principalTable: "Bosses",
                        principalColumn: "BossId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FullSets_Gears_GearId",
                        column: x => x.GearId,
                        principalTable: "Gears",
                        principalColumn: "GearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BossDrops_BossId",
                table: "BossDrops",
                column: "BossId");

            migrationBuilder.CreateIndex(
                name: "IX_BossDrops_DropId",
                table: "BossDrops",
                column: "DropId");

            migrationBuilder.CreateIndex(
                name: "IX_FullSets_BossId",
                table: "FullSets",
                column: "BossId");

            migrationBuilder.CreateIndex(
                name: "IX_FullSets_GearId",
                table: "FullSets",
                column: "GearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BossDrops");

            migrationBuilder.DropTable(
                name: "FullSets");

            migrationBuilder.DropTable(
                name: "Drops");

            migrationBuilder.DropTable(
                name: "Bosses");

            migrationBuilder.DropTable(
                name: "Gears");
        }
    }
}
