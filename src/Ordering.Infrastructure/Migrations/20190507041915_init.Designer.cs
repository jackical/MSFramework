﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ordering.Infrastructure;

namespace Ordering.Infrastructure.Migrations
{
    [DbContext(typeof(OrderingContext))]
    [Migration("20190507041915_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Discount");

                    b.Property<Guid?>("OrderId");

                    b.Property<string>("PictureUrl");

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<decimal>("UnitPrice");

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.Order", b =>
                {
                    b.OwnsOne("Ordering.Domain.AggregateRoot.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("OrderId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("State");

                            b1.Property<string>("Street");

                            b1.Property<string>("ZipCode");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.HasOne("Ordering.Domain.AggregateRoot.Order")
                                .WithOne("Address")
                                .HasForeignKey("Ordering.Domain.AggregateRoot.Address", "OrderId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Ordering.Domain.AggregateRoot.OrderItem", b =>
                {
                    b.HasOne("Ordering.Domain.AggregateRoot.Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
