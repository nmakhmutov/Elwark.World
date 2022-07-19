﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using World.Api.Infrastructure;

#nullable disable

namespace World.Api.Infrastructure.Migrations
{
    [DbContext(typeof(WorldDbContext))]
    partial class WorldDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("World.Api.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Alpha2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("alpha2");

                    b.Property<string>("Alpha3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("alpha3");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("flag");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("region");

                    b.Property<int>("StartOfWeek")
                        .HasColumnType("integer")
                        .HasColumnName("start_of_week");

                    b.Property<string>("Subregion")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("subregion");

                    b.HasKey("Id");

                    b.HasAlternateKey("Alpha2");

                    b.HasAlternateKey("Alpha3");

                    b.HasIndex("Region");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("World.Api.Models.CountryTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Common")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("common");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("language");

                    b.Property<string>("Official")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("official");

                    b.HasKey("Id");

                    b.HasAlternateKey("CountryId", "Language");

                    b.ToTable("country_translations", (string)null);
                });

            modelBuilder.Entity("World.Api.Models.TimeZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("name");

                    b.Property<TimeSpan>("UtcOffset")
                        .HasColumnType("interval")
                        .HasColumnName("utc_offset");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("time_zones", (string)null);
                });

            modelBuilder.Entity("World.Api.Models.TimeZoneTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("display_name");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("language");

                    b.Property<string>("StandardName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("standard_name");

                    b.Property<int>("TimeZoneId")
                        .HasColumnType("integer")
                        .HasColumnName("time_zone_id");

                    b.HasKey("Id");

                    b.HasAlternateKey("TimeZoneId", "Language");

                    b.ToTable("time_zone_translations", (string)null);
                });

            modelBuilder.Entity("World.Api.Models.CountryTranslation", b =>
                {
                    b.HasOne("World.Api.Models.Country", null)
                        .WithMany("Translations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("World.Api.Models.TimeZoneTranslation", b =>
                {
                    b.HasOne("World.Api.Models.TimeZone", null)
                        .WithMany("Translations")
                        .HasForeignKey("TimeZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("World.Api.Models.Country", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("World.Api.Models.TimeZone", b =>
                {
                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
