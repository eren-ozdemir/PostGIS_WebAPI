﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PostGIS_WebAPI.REPOSITORIES.Context;

#nullable disable

namespace PostGIS_WebAPI.REPOSITORIES.Migrations
{
    [DbContext(typeof(CityContext))]
    partial class CityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PostGIS_WebAPI.ENTITIES.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BuildingType")
                        .HasColumnType("text")
                        .HasColumnName("building_type");

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<string>("FClass")
                        .HasColumnType("text")
                        .HasColumnName("fclass");

                    b.Property<char>("GeomType")
                        .HasColumnType("character(1)")
                        .HasColumnName("geomtype");

                    b.Property<Geometry>("Geometry")
                        .HasColumnType("geometry")
                        .HasColumnName("geometry");

                    b.Property<int>("Height")
                        .HasColumnType("integer")
                        .HasColumnName("height");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("isactive");

                    b.Property<string>("LastChange")
                        .HasColumnType("text")
                        .HasColumnName("lastchange");

                    b.Property<int>("Levels")
                        .HasColumnType("integer")
                        .HasColumnName("levels");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Osm_Id")
                        .HasColumnType("text")
                        .HasColumnName("osm_id");

                    b.Property<string>("Type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_buildings");

                    b.ToTable("buildings", "public");
                });
#pragma warning restore 612, 618
        }
    }
}
