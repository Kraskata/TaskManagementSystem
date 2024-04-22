﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystem.Infrastructure.Data;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(TaskManagementDbContext))]
    [Migration("20240411141957_AdminPasswordCorrected")]
    partial class AdminPasswordCorrected
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TaskManagementSystem.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "89f9e2d2-3fd0-4f9d-bb31-7ab0b27c2b84",
                            Email = "assignee@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Assignee",
                            LastName = "Assigneev",
                            LockoutEnabled = false,
                            NormalizedEmail = "assignee@mail.com",
                            NormalizedUserName = "agent@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAECRUFexZFlv/qp/jkn6VjEmrzQ6x0OoS206RQThZizQhDqcDNKzejugeyfirl4aHww==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4f247dc6-a5bc-47c1-a19d-bb3cfcd0b4cb",
                            TwoFactorEnabled = false,
                            UserName = "assignee@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "48a8e5f0-3980-4c30-a13b-8d291925dfbf",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Guest",
                            LastName = "Guestov",
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEKQps2cUlCbbF70YtWAnyjE++TGm+CG7fJaI3QXdDoVb7gkkixRUn2syxijISGv2Gg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "edec942d-81ad-4217-881f-b9ec1e7d5253",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        },
                        new
                        {
                            Id = "15480979-8cbd-44cf-a085-f7e32c1b50f2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "301a5080-bbd1-41e7-9c57-faf1b6bfd894",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Adminov",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@MAIL.COM",
                            NormalizedUserName = "admin@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPhjeoAUxyOuxN4VsJrE+4I/onKw8s4TyGPPAj6ImNMBIjCjb+KxtmEYsRIf8tKSTg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f91bfec4-ab7d-49f6-8362-3d7b8b37bad6",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Infrastructure.Data.Models.Assignee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Assignee identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Assignee's Gmail, Must Be G-Mail, Regex Checked");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Assignee's phone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Assignees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gmail = "",
                            PhoneNumber = "+359888888888",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 6,
                            Gmail = "",
                            PhoneNumber = "+359888888887",
                            UserId = "15480979-8cbd-44cf-a085-f7e32c1b50f2"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Infrastructure.Data.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Task Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Assigned")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Task Assigned Date");

                    b.Property<int>("AssigneeId")
                        .HasColumnType("int")
                        .HasComment("Assignee identifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Identifier For Task Category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Task Description");

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Task Done By Date");

                    b.Property<decimal>("Paid")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Assignment Paid Upon Completion");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Task Title/Name");

                    b.Property<string>("WorkerId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("User id of the worker accepting the task");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Assignments");

                    b.HasComment("Task To Do");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Assigned = "03/01/2024",
                            AssigneeId = 1,
                            CategoryId = 2,
                            Description = "Find a way to test if the application is durable to pressure.",
                            DoneBy = "04/15/2024",
                            Paid = 2100.00m,
                            Title = "Pressure Test",
                            WorkerId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 1,
                            Assigned = "03/27/2024",
                            AssigneeId = 1,
                            CategoryId = 3,
                            Description = "The domain tables have the wrong properties.",
                            DoneBy = "04/05/2024",
                            Paid = 2100.00m,
                            Title = "Domain Tables",
                            WorkerId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 2,
                            Assigned = "03/23/2024",
                            AssigneeId = 1,
                            CategoryId = 1,
                            Description = "We require more guest users, alongside a new level of threat inside the categories (modify the domain tables).",
                            DoneBy = "05/22/2024",
                            Paid = 2100.00m,
                            Title = "More Data Seeded Needed (Testing Purposes)",
                            WorkerId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Task Category");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Name = "Critical"
                        },
                        new
                        {
                            Id = 2,
                            Name = "High Threat"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Minimal"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TaskManagementSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TaskManagementSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagementSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TaskManagementSystem.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagementSystem.Infrastructure.Data.Models.Assignee", b =>
                {
                    b.HasOne("TaskManagementSystem.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagementSystem.Infrastructure.Data.Models.Assignment", b =>
                {
                    b.HasOne("TaskManagementSystem.Infrastructure.Data.Models.Assignee", "Assignee")
                        .WithMany("Assignments")
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagementSystem.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Assignments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TaskManagementSystem.Infrastructure.Data.Models.Assignee", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("TaskManagementSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}