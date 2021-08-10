﻿// <auto-generated />
using System;
using DOService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DOService.Migrations
{
    [DbContext(typeof(DOServiceContext))]
    partial class DOServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DOService.Models.DoiHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("approved_date");

                    b.Property<bool>("ApprovedFlag")
                        .HasColumnType("boolean")
                        .HasColumnName("approved_flag");

                    b.Property<string>("ApprovedUserId")
                        .HasColumnType("text")
                        .HasColumnName("approved_user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid")
                        .HasColumnName("organization_id");

                    b.Property<Guid?>("organization_id")
                        .HasColumnType("uuid")
                        .HasColumnName("organization_id1");

                    b.HasKey("Id");

                    b.HasIndex("organization_id");

                    b.ToTable("doi_headers");
                });

            modelBuilder.Entity("DOService.Models.DoiOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BurdenGroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("burden_group_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<Guid>("DoiHeaderId")
                        .HasColumnType("uuid")
                        .HasColumnName("doi_header_id");

                    b.Property<DateTime>("EffectiveFromDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("effective_from_date");

                    b.Property<DateTime>("EffectiveToDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("effective_to_date");

                    b.Property<string>("InterestType")
                        .HasColumnType("text")
                        .HasColumnName("interest_type");

                    b.Property<decimal>("NriDecimal")
                        .HasColumnType("numeric")
                        .HasColumnName("nri_decimal");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid")
                        .HasColumnName("organization_id");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<string>("OwnerName")
                        .HasColumnType("text")
                        .HasColumnName("owner_name");

                    b.Property<string>("PayCode")
                        .HasColumnType("text")
                        .HasColumnName("pay_code");

                    b.Property<string>("SuspenseReason")
                        .HasColumnType("text")
                        .HasColumnName("suspense_reason");

                    b.HasKey("Id");

                    b.ToTable("doi_owners");
                });

            modelBuilder.Entity("DOService.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("organizations");
                });

            modelBuilder.Entity("DOService.Models.DoiHeader", b =>
                {
                    b.HasOne("DOService.Models.Organization", "Organization")
                        .WithMany("DoiHeaders")
                        .HasForeignKey("organization_id");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DOService.Models.Organization", b =>
                {
                    b.Navigation("DoiHeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
