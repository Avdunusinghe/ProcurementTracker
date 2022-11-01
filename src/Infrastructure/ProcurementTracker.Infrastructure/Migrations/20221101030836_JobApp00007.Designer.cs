﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcurementTracker.Infrastructure.Data;

#nullable disable

namespace ProcurementTracker.Infrastructure.Migrations
{
    [DbContext(typeof(ProcurementTrackerContext))]
    [Migration("20221101030836_JobApp00007")]
    partial class JobApp00007
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedById")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsProceesed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastUpdatedById")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long>("OrderByUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("OrderByUserId");

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedById")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastUpdatedById")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.ProductImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AttachementName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Attachment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.PurchaseRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedById")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastUpdatedById")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("PurchaseRequestStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequiredDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("StatusChangedById")
                        .HasColumnType("bigint");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("StatusChangedById");

                    b.HasIndex("SupplierId");

                    b.ToTable("PurchaseRequest", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.PurchaseRequestProductItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("NumberOfItem")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("PurchaseRequestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseRequestId");

                    b.ToTable("PurchaseRequestProductItem", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedById")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastUpdatedById")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.SupplierProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierProduct", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoggedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LastUpdatedById")
                        .HasColumnType("bigint");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Order", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedOrders")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.User", "LastUpdatedBy")
                        .WithMany("UpdatedOrders")
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.User", "OrderBy")
                        .WithMany("PlaceOders")
                        .HasForeignKey("OrderByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.Supplier", "Supplier")
                        .WithOne("Order")
                        .HasForeignKey("ProcurementTracker.Domain.Entities.Order", "SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");

                    b.Navigation("OrderBy");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Product", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedProducts")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.User", "LastUpdatedBy")
                        .WithMany("UpdatedProducts")
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.PurchaseRequest", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedPurchaseRequests")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.User", "LastUpdatedBy")
                        .WithMany("UpdatedPurchaseRequests")
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.User", "StatusChangedBy")
                        .WithMany("StatusChangedPurchaseRequests")
                        .HasForeignKey("StatusChangedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProcurementTracker.Domain.Entities.Supplier", "Supplier")
                        .WithMany("purchaseRequests")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");

                    b.Navigation("StatusChangedBy");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.PurchaseRequestProductItem", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.Product", "Product")
                        .WithMany("PurchaseRequestProductItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProcurementTracker.Domain.Entities.PurchaseRequest", "PurchaseRequest")
                        .WithMany("PurchaseRequestProductItems")
                        .HasForeignKey("PurchaseRequestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Product");

                    b.Navigation("PurchaseRequest");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Supplier", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedSuppliers")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProcurementTracker.Domain.Entities.User", "LastUpdatedBy")
                        .WithMany("UpdatedSuppliers")
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.SupplierProduct", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.Product", "Product")
                        .WithMany("SupplierProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProcurementTracker.Domain.Entities.Supplier", "Supplier")
                        .WithMany("SupplierProducts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.User", b =>
                {
                    b.HasOne("ProcurementTracker.Domain.Entities.User", "CreatedBy")
                        .WithMany("CreatedUsers")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProcurementTracker.Domain.Entities.User", "LastUpdatedBy")
                        .WithMany("UpdatedUsers")
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProcurementTracker.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("ProductImages");

                    b.Navigation("PurchaseRequestProductItems");

                    b.Navigation("SupplierProducts");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.PurchaseRequest", b =>
                {
                    b.Navigation("PurchaseRequestProductItems");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.Supplier", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("SupplierProducts");

                    b.Navigation("purchaseRequests");
                });

            modelBuilder.Entity("ProcurementTracker.Domain.Entities.User", b =>
                {
                    b.Navigation("CreatedOrders");

                    b.Navigation("CreatedProducts");

                    b.Navigation("CreatedPurchaseRequests");

                    b.Navigation("CreatedSuppliers");

                    b.Navigation("CreatedUsers");

                    b.Navigation("PlaceOders");

                    b.Navigation("StatusChangedPurchaseRequests");

                    b.Navigation("UpdatedOrders");

                    b.Navigation("UpdatedProducts");

                    b.Navigation("UpdatedPurchaseRequests");

                    b.Navigation("UpdatedSuppliers");

                    b.Navigation("UpdatedUsers");
                });
#pragma warning restore 612, 618
        }
    }
}