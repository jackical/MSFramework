﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ordering.Infrastructure.Migrations
{
    [DbContext(typeof(OrderingContext))]
    partial class OrderingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MicroserviceFramework.Audits.AuditEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("EntityId")
                        .HasColumnName("entity_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("OperationId")
                        .HasColumnName("operation_id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("OperationType")
                        .HasColumnName("operation_type")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Type")
                        .HasColumnName("type_name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("audit_operation_id")
                        .HasColumnName("audit_operation_id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("OperationId");

                    b.HasIndex("audit_operation_id");

                    b.ToTable("audit_entity");
                });

            modelBuilder.Entity("MicroserviceFramework.Audits.AuditOperation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("ApplicationName")
                        .HasColumnName("application_name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("int");

                    b.Property<string>("CreationUserId")
                        .HasColumnName("creation_user_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("CreationUserName")
                        .HasColumnName("creation_user_name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("Elapsed")
                        .HasColumnName("elapsed")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnName("end_time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ip")
                        .HasColumnName("ip")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Path")
                        .HasColumnName("path")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("UserAgent")
                        .HasColumnName("user_agent")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("CreationTime");

                    b.HasIndex("CreationUserId");

                    b.HasIndex("EndTime");

                    b.ToTable("audit_operation");
                });

            modelBuilder.Entity("MicroserviceFramework.Audits.AuditProperty", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("EntityId")
                        .HasColumnName("entity_id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("NewValue")
                        .HasColumnName("new_value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OriginalValue")
                        .HasColumnName("original_value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("audit_entity_id")
                        .HasColumnName("audit_entity_id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("audit_entity_id");

                    b.ToTable("audit_property");
                });

            modelBuilder.Entity("MicroserviceFramework.Functions.Function", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("int");

                    b.Property<string>("CreationUserId")
                        .HasColumnName("creation_user_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("CreationUserName")
                        .HasColumnName("creation_user_name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(2000) CHARACTER SET utf8mb4")
                        .HasMaxLength(2000);

                    b.Property<bool>("Enabled")
                        .HasColumnName("enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Expired")
                        .HasColumnName("expired")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ModificationTime")
                        .HasColumnName("modification_time")
                        .HasColumnType("int");

                    b.Property<string>("ModificationUserId")
                        .HasColumnName("modification_user_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("ModificationUserName")
                        .HasColumnName("modification_user_name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name");

                    b.ToTable("function");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoots.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderStatus")
                        .HasColumnName("order_status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoots.OrderItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<decimal>("Discount")
                        .HasColumnName("discount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("PictureUrl")
                        .HasColumnName("picture_url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("unit_price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Units")
                        .HasColumnName("units")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoots.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<int>("Price")
                        .HasColumnName("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("MicroserviceFramework.Audits.AuditEntity", b =>
                {
                    b.HasOne("MicroserviceFramework.Audits.AuditOperation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId");

                    b.HasOne("MicroserviceFramework.Audits.AuditOperation", null)
                        .WithMany("Entities")
                        .HasForeignKey("audit_operation_id");
                });

            modelBuilder.Entity("MicroserviceFramework.Audits.AuditProperty", b =>
                {
                    b.HasOne("MicroserviceFramework.Audits.AuditEntity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.HasOne("MicroserviceFramework.Audits.AuditEntity", null)
                        .WithMany("Properties")
                        .HasForeignKey("audit_entity_id");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoots.Order", b =>
                {
                    b.OwnsOne("Ordering.Domain.AggregateRoots.Address", "Address", b1 =>
                        {
                            b1.Property<string>("OrderId")
                                .HasColumnName("id")
                                .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                            b1.Property<string>("City")
                                .HasColumnName("address_city")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Country")
                                .HasColumnName("address_country")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("State")
                                .HasColumnName("address_state")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Street")
                                .HasColumnName("address_street")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("ZipCode")
                                .HasColumnName("address_zip_code")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("OrderId");

                            b1.ToTable("order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoots.OrderItem", b =>
                {
                    b.HasOne("Ordering.Domain.AggregateRoots.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
