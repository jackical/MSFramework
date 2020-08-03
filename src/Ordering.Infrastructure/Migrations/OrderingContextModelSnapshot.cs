﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ordering.Infrastructure;

namespace Ordering.Infrastructure.Migrations
{
    [DbContext(typeof(OrderingContext))]
    partial class OrderingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MSFramework.Audit.AuditEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("EntityId")
                        .HasColumnName("entity_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("OperationId")
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
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("OperationId");

                    b.HasIndex("audit_operation_id");

                    b.ToTable("audit_entity");
                });

            modelBuilder.Entity("MSFramework.Audit.AuditOperation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("ApplicationName")
                        .HasColumnName("application_name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreationUserId")
                        .HasColumnName("creation_user_id")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("CreationUserName")
                        .HasColumnName("creation_user_name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

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

            modelBuilder.Entity("MSFramework.Audit.AuditProperty", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("EntityId")
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
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("audit_entity_id");

                    b.ToTable("audit_property");
                });

            modelBuilder.Entity("MSFramework.Function.FunctionDefine", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreationUserId")
                        .HasColumnName("creation_user_id")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("CreationUserName")
                        .HasColumnName("creation_user_name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

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

                    b.Property<DateTimeOffset?>("LastModificationTime")
                        .HasColumnName("last_modification_time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModificationUserId")
                        .HasColumnName("last_modification_user_id")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("LastModificationUserName")
                        .HasColumnName("last_modification_user_name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

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

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.OrderItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MSFramework.Audit.AuditEntity", b =>
                {
                    b.HasOne("MSFramework.Audit.AuditOperation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId");

                    b.HasOne("MSFramework.Audit.AuditOperation", null)
                        .WithMany("Entities")
                        .HasForeignKey("audit_operation_id");
                });

            modelBuilder.Entity("MSFramework.Audit.AuditProperty", b =>
                {
                    b.HasOne("MSFramework.Audit.AuditEntity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.HasOne("MSFramework.Audit.AuditEntity", null)
                        .WithMany("Properties")
                        .HasForeignKey("audit_entity_id");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.Order", b =>
                {
                    b.OwnsOne("Ordering.Domain.AggregateRoot.Address", "Address", b1 =>
                        {
                            b1.Property<string>("OrderId")
                                .HasColumnType("varchar(36) CHARACTER SET utf8mb4");

                            b1.Property<string>("City")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Country")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("State")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Street")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.OrderItem", b =>
                {
                    b.HasOne("Ordering.Domain.AggregateRoot.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
