using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GearOptimizer.Model;

namespace GearOptimizer.Migrations
{
    [DbContext(typeof(GearOptimizerDbContext))]
    [Migration("20170422044320_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GearOptimizer.Model.Boss", b =>
                {
                    b.Property<int>("BossId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AtkStyle");

                    b.Property<string>("Name");

                    b.Property<string>("Weakness");

                    b.HasKey("BossId");

                    b.ToTable("Bosses");
                });

            modelBuilder.Entity("GearOptimizer.Model.BossDrops", b =>
                {
                    b.Property<int>("BossId");

                    b.Property<int>("DropId");

                    b.HasKey("BossId", "DropId");

                    b.HasIndex("BossId");

                    b.HasIndex("DropId");

                    b.ToTable("BossDrops");
                });

            modelBuilder.Entity("GearOptimizer.Model.Drop", b =>
                {
                    b.Property<int>("DropId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Value");

                    b.HasKey("DropId");

                    b.ToTable("Drops");
                });

            modelBuilder.Entity("GearOptimizer.Model.FullSet", b =>
                {
                    b.Property<string>("SetType");

                    b.Property<int>("ArrowSlotId");

                    b.Property<int>("BootsId");

                    b.Property<int>("BossId");

                    b.Property<int>("CapeId");

                    b.Property<int>("ChestSlotId");

                    b.Property<int>("FullSetId");

                    b.Property<int?>("GearId");

                    b.Property<int>("GlovesId");

                    b.Property<int>("HeadSlotId");

                    b.Property<int>("LegSlotId");

                    b.Property<int>("MainHandId");

                    b.Property<int>("NecklaceId");

                    b.Property<int>("OffHandId");

                    b.Property<int>("RingId");

                    b.HasKey("SetType");

                    b.HasIndex("BossId");

                    b.HasIndex("GearId");

                    b.ToTable("FullSets");
                });

            modelBuilder.Entity("GearOptimizer.Model.Gear", b =>
                {
                    b.Property<int>("GearId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtkCrush");

                    b.Property<int>("AtkMagic");

                    b.Property<int>("AtkRange");

                    b.Property<int>("AtkSlash");

                    b.Property<int>("AtkStab");

                    b.Property<int>("DefCrush");

                    b.Property<int>("DefMagic");

                    b.Property<int>("DefRange");

                    b.Property<int>("DefSlash");

                    b.Property<int>("DefStab");

                    b.Property<int>("MagicDmg");

                    b.Property<int>("MeleeStr");

                    b.Property<string>("Name");

                    b.Property<int>("Prayer");

                    b.Property<int>("Price");

                    b.Property<int>("RangeStr");

                    b.Property<int>("Slayer");

                    b.Property<string>("Slot");

                    b.Property<int>("Undead");

                    b.HasKey("GearId");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("GearOptimizer.Model.BossDrops", b =>
                {
                    b.HasOne("GearOptimizer.Model.Boss", "Boss")
                        .WithMany("BossDrops")
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Model.Drop", "Drop")
                        .WithMany("BossDrops")
                        .HasForeignKey("DropId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GearOptimizer.Model.FullSet", b =>
                {
                    b.HasOne("GearOptimizer.Model.Boss", "Boss")
                        .WithMany("FullSets")
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Model.Gear")
                        .WithMany("FullSets")
                        .HasForeignKey("GearId");
                });
        }
    }
}
