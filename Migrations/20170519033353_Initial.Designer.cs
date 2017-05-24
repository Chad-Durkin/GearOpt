using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GearOptimizer.Models;

namespace GearOptimizer.Migrations
{
    [DbContext(typeof(GearOptimizerDbContext))]
    [Migration("20170519033353_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GearOptimizer.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GearOptimizer.Models.Boss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AtkStyle");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("PopGroupSize");

                    b.Property<string>("Weakness");

                    b.HasKey("Id");

                    b.ToTable("Bosses");
                });

            modelBuilder.Entity("GearOptimizer.Models.BossDrop", b =>
                {
                    b.Property<int>("BossId");

                    b.Property<int>("DropId");

                    b.HasKey("BossId", "DropId");

                    b.HasIndex("BossId");

                    b.HasIndex("DropId");

                    b.ToTable("BossDrops");
                });

            modelBuilder.Entity("GearOptimizer.Models.Drop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Drops");
                });

            modelBuilder.Entity("GearOptimizer.Models.FullSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BossId");

                    b.Property<string>("SetName");

                    b.HasKey("Id");

                    b.ToTable("FullSets");
                });

            modelBuilder.Entity("GearOptimizer.Models.FullSetBoss", b =>
                {
                    b.Property<int>("FullSetId");

                    b.Property<int>("BossId");

                    b.HasKey("FullSetId", "BossId");

                    b.HasIndex("BossId");

                    b.HasIndex("FullSetId");

                    b.ToTable("FullSetBosses");
                });

            modelBuilder.Entity("GearOptimizer.Models.FullSetGear", b =>
                {
                    b.Property<int>("FullSetId");

                    b.Property<int>("GearId");

                    b.HasKey("FullSetId", "GearId");

                    b.HasIndex("FullSetId");

                    b.HasIndex("GearId");

                    b.ToTable("FullSetGears");
                });

            modelBuilder.Entity("GearOptimizer.Models.Gear", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<string>("Reqs");

                    b.Property<int>("Slayer");

                    b.Property<string>("Slot");

                    b.Property<int>("Undead");

                    b.HasKey("Id");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("GearOptimizer.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("GearOptimizer.Models.ProfileFullSet", b =>
                {
                    b.Property<int>("FullSetId");

                    b.Property<int>("ProfileId");

                    b.HasKey("FullSetId", "ProfileId");

                    b.HasIndex("FullSetId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileFullSets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GearOptimizer.Models.BossDrop", b =>
                {
                    b.HasOne("GearOptimizer.Models.Boss", "Boss")
                        .WithMany("BossDrops")
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Models.Drop", "Drop")
                        .WithMany("BossDrops")
                        .HasForeignKey("DropId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GearOptimizer.Models.FullSetBoss", b =>
                {
                    b.HasOne("GearOptimizer.Models.Boss", "Boss")
                        .WithMany("FullSetBosses")
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Models.FullSet", "FullSet")
                        .WithMany("FullSetBosses")
                        .HasForeignKey("FullSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GearOptimizer.Models.FullSetGear", b =>
                {
                    b.HasOne("GearOptimizer.Models.FullSet", "FullSet")
                        .WithMany("FullSetGears")
                        .HasForeignKey("FullSetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Models.Gear", "Gear")
                        .WithMany("FullSetGears")
                        .HasForeignKey("GearId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GearOptimizer.Models.Profile", b =>
                {
                    b.HasOne("GearOptimizer.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("GearOptimizer.Models.ProfileFullSet", b =>
                {
                    b.HasOne("GearOptimizer.Models.FullSet", "FullSet")
                        .WithMany("ProfileFullSets")
                        .HasForeignKey("FullSetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Models.Profile", "Profile")
                        .WithMany("ProfileFullSets")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GearOptimizer.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GearOptimizer.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
