﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data_access.data;

#nullable disable

namespace data_access.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240126122340_AddedFakeDataForTest")]
    partial class AddedFakeDataForTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("data_access.Entities.AdvertisePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMainPicture")
                        .HasColumnType("bit");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("AdvertisePictures");
                });

            modelBuilder.Entity("data_access.Entities.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvertisementStatusId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeliveryContactInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementStatusId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DeliveryContactInfoId");

                    b.HasIndex("UserId");

                    b.ToTable("Advertisements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdvertisementStatusId = 2,
                            CategoryId = 12,
                            City = "Kyiv",
                            Description = "New phone with waranty",
                            Price = 67399m,
                            Title = "iPhone 13 Pro Max 512Gb",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("data_access.Entities.AdvertisementStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdvertisementStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Active"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Unactive"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Deleted"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Archive"
                        });
                });

            modelBuilder.Entity("data_access.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Child wares"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cars"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Transports parts"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Jobs"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Animals"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Home and garden"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Business and commerce"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Rents and hires"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Fashion & Style"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Hobbies, leisure and sports"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Phones and accessories",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 13,
                            Name = "Audio",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 14,
                            Name = "Home appliances",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 15,
                            Name = "Accessories and components",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 16,
                            Name = "Computers and components",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 17,
                            Name = "Games and consoles",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 18,
                            Name = "Appliance for kitchen",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 19,
                            Name = "Other appliance",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 20,
                            Name = "Photo and video",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 21,
                            Name = "Tablets / Ebooks",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 22,
                            Name = "HVAC equipment",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 23,
                            Name = "Repair of equipment",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 24,
                            Name = "TV / Video",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            Id = 25,
                            Name = "Laptops and accessories",
                            ParentCategoryId = 7
                        });
                });

            modelBuilder.Entity("data_access.Entities.DeliveryCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryCompanies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "UkrPoshta"
                        },
                        new
                        {
                            Id = 2,
                            Name = "NovaPoshta"
                        },
                        new
                        {
                            Id = 3,
                            Name = "MeestExpress"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delivery"
                        });
                });

            modelBuilder.Entity("data_access.Entities.DeliveryContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeliveryCompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryHomeAddressId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryHomeAdrdessId")
                        .HasColumnType("int");

                    b.Property<string>("PostOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryCompanyId");

                    b.HasIndex("DeliveryHomeAdrdessId");

                    b.ToTable("DeliveryContactInfos");
                });

            modelBuilder.Entity("data_access.Entities.DeliveryHomeAdrdess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Appartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Build")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtraInfoForCourier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryHomeAdrdesses");
                });

            modelBuilder.Entity("data_access.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", t =>
                        {
                            t.HasCheckConstraint("CK_Entity_Email", "Email LIKE '%_@_%._%'");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "johndoe@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "0972463461"
                        },
                        new
                        {
                            Id = 2,
                            Email = "valterscott@gmail.com",
                            FirstName = "Valter",
                            LastName = "Scott",
                            Phone = "0954285352"
                        },
                        new
                        {
                            Id = 3,
                            Email = "danielgreen@gmail.com",
                            FirstName = "Daniel",
                            LastName = "Green",
                            Phone = "0735520395"
                        },
                        new
                        {
                            Id = 4,
                            Email = "abraham@gmail.com",
                            FirstName = "Abraham",
                            LastName = "Eddison",
                            Phone = "0994725481"
                        });
                });

            modelBuilder.Entity("data_access.Entities.AdvertisePicture", b =>
                {
                    b.HasOne("data_access.Entities.Advertisement", "Advertisement")
                        .WithMany("AdvertisePictures")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");
                });

            modelBuilder.Entity("data_access.Entities.Advertisement", b =>
                {
                    b.HasOne("data_access.Entities.AdvertisementStatus", "AdvertisementStatus")
                        .WithMany("Advertisements")
                        .HasForeignKey("AdvertisementStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Entities.Category", "Category")
                        .WithMany("Advertisements")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Entities.DeliveryContactInfo", "DeliveryContactInfo")
                        .WithMany("Advertisements")
                        .HasForeignKey("DeliveryContactInfoId");

                    b.HasOne("data_access.Entities.User", "User")
                        .WithMany("Advertisements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdvertisementStatus");

                    b.Navigation("Category");

                    b.Navigation("DeliveryContactInfo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("data_access.Entities.Category", b =>
                {
                    b.HasOne("data_access.Entities.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("data_access.Entities.DeliveryContactInfo", b =>
                {
                    b.HasOne("data_access.Entities.DeliveryCompany", "DeliveryCompany")
                        .WithMany("DeliveryContactInfos")
                        .HasForeignKey("DeliveryCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Entities.DeliveryHomeAdrdess", "DeliveryHomeAdrdess")
                        .WithMany("DeliveryContactInfos")
                        .HasForeignKey("DeliveryHomeAdrdessId");

                    b.Navigation("DeliveryCompany");

                    b.Navigation("DeliveryHomeAdrdess");
                });

            modelBuilder.Entity("data_access.Entities.Advertisement", b =>
                {
                    b.Navigation("AdvertisePictures");
                });

            modelBuilder.Entity("data_access.Entities.AdvertisementStatus", b =>
                {
                    b.Navigation("Advertisements");
                });

            modelBuilder.Entity("data_access.Entities.Category", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("data_access.Entities.DeliveryCompany", b =>
                {
                    b.Navigation("DeliveryContactInfos");
                });

            modelBuilder.Entity("data_access.Entities.DeliveryContactInfo", b =>
                {
                    b.Navigation("Advertisements");
                });

            modelBuilder.Entity("data_access.Entities.DeliveryHomeAdrdess", b =>
                {
                    b.Navigation("DeliveryContactInfos");
                });

            modelBuilder.Entity("data_access.Entities.User", b =>
                {
                    b.Navigation("Advertisements");
                });
#pragma warning restore 612, 618
        }
    }
}
