using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataAccess.Interface.EntityFramework;

namespace DataAccess.Interface.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170108145631_FirstMigrations")]
    partial class FirstMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("DataAccess.Interface.EntityFramework.MusicModel", b =>
                {
                    b.Property<int>("MusicModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<byte[]>("ConvertedContent");

                    b.Property<string>("Name");

                    b.HasKey("MusicModelId");

                    b.ToTable("MusicModel");
                });
        }
    }
}
