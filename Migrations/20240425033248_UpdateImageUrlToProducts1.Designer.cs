﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineGroceryStore.Models.Data;

#nullable disable

namespace OnlineGroceryStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240425033248_UpdateImageUrlToProducts1")]
    partial class UpdateImageUrlToProducts1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineGroceryStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            ImageUrl = "/images/cat-1.png",
                            Name = "Fruits"
                        },
                        new
                        {
                            CategoryId = 2,
                            ImageUrl = "/images/cat-2.png",
                            Name = "Vegetables"
                        },
                        new
                        {
                            CategoryId = 3,
                            ImageUrl = "/images/cat-3.png",
                            Name = "Dairy"
                        },
                        new
                        {
                            CategoryId = 4,
                            ImageUrl = "/images/cat-4.png",
                            Name = "Beverages"
                        });
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Description = "Fresh Oranges",
                            ImageUrl = "images/Product Images/Orange.jpg",
                            Name = "Orange",
                            Price = 0.5,
                            StockQuantity = 150,
                            SubCategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            Description = "Organic Carrots",
                            ImageUrl = "images/Product Images/Carrot.jpg",
                            Name = "Carrot",
                            Price = 0.20000000000000001,
                            StockQuantity = 200,
                            SubCategoryId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            Description = "Fresh Spinach",
                            ImageUrl = "images/Product Images/Spinach.jpg",
                            Name = "Spinach",
                            Price = 1.0,
                            StockQuantity = 100,
                            SubCategoryId = 3
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 3,
                            Description = "Creamy Whole Milk",
                            ImageUrl = "images/Product Images/WholeMilk.jpg",
                            Name = "Whole Milk",
                            Price = 0.89000000000000001,
                            StockQuantity = 300,
                            SubCategoryId = 4
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 3,
                            Description = "Aged Cheddar Cheese",
                            ImageUrl = "images/Product Images/CheddarCheese.jpg",
                            Name = "Cheddar Cheese",
                            Price = 2.5,
                            StockQuantity = 95,
                            SubCategoryId = 5
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 4,
                            Description = "Classic Coca Cola",
                            ImageUrl = "images/Product Images/CocaCola.jpg",
                            Name = "Coca Cola",
                            Price = 1.25,
                            StockQuantity = 500,
                            SubCategoryId = 6
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 4,
                            Description = "Pure Apple Juice",
                            ImageUrl = "images/Product Images/AppleJuice.jpg",
                            Name = "Apple Juice",
                            Price = 1.5,
                            StockQuantity = 150,
                            SubCategoryId = 7
                        });
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            SubCategoryId = 1,
                            CategoryId = 1,
                            Name = "Citrus"
                        },
                        new
                        {
                            SubCategoryId = 2,
                            CategoryId = 2,
                            Name = "Root"
                        },
                        new
                        {
                            SubCategoryId = 3,
                            CategoryId = 2,
                            Name = "Leafy Greens"
                        },
                        new
                        {
                            SubCategoryId = 4,
                            CategoryId = 3,
                            Name = "Milk"
                        },
                        new
                        {
                            SubCategoryId = 5,
                            CategoryId = 3,
                            Name = "Cheese"
                        },
                        new
                        {
                            SubCategoryId = 6,
                            CategoryId = 4,
                            Name = "Sodas"
                        },
                        new
                        {
                            SubCategoryId = 7,
                            CategoryId = 4,
                            Name = "Juices"
                        });
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.Order", b =>
                {
                    b.HasOne("OnlineGroceryStore.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.OrderDetail", b =>
                {
                    b.HasOne("OnlineGroceryStore.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineGroceryStore.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.Product", b =>
                {
                    b.HasOne("OnlineGroceryStore.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineGroceryStore.Models.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.SubCategory", b =>
                {
                    b.HasOne("OnlineGroceryStore.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.SubCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineGroceryStore.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
