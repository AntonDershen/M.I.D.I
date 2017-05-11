using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataAccess.Interface.EntityFramework;

namespace DataAccess.Interface.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170501182927_migration2")]
    partial class migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("DataAccess.Interface.EntityFramework.AlbumModel", b =>
                {
                    b.Property<int>("AlbumModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.HasKey("AlbumModelId");

                    b.ToTable("AlbumModel");
                });

            modelBuilder.Entity("DataAccess.Interface.EntityFramework.ConvertedMusicModel", b =>
                {
                    b.Property<int>("ConvertedMusicModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ConvertedDate");

                    b.HasKey("ConvertedMusicModelId");

                    b.ToTable("ConvertedMusicModel");
                });

            modelBuilder.Entity("DataAccess.Interface.EntityFramework.MusicModel", b =>
                {
                    b.Property<int>("MusicModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumModelId");

                    b.Property<byte[]>("Content");

                    b.Property<int?>("ConvertedMusicModelId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Extension");

                    b.Property<string>("Name");

                    b.HasKey("MusicModelId");

                    b.HasIndex("AlbumModelId");

                    b.HasIndex("ConvertedMusicModelId");

                    b.ToTable("MusicModel");
                });

            modelBuilder.Entity("DataAccess.Interface.EntityFramework.NoteModel", b =>
                {
                    b.Property<int>("NoteModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Channel");

                    b.Property<int>("CommandCode");

                    b.Property<int?>("ConvertedMusicModelId");

                    b.Property<int>("NoteNumber");

                    b.Property<double>("RealTime");

                    b.HasKey("NoteModelId");

                    b.HasIndex("ConvertedMusicModelId");

                    b.ToTable("NoteModel");
                });

            modelBuilder.Entity("DataAccess.Interface.EntityFramework.MusicModel", b =>
                {
                    b.HasOne("DataAccess.Interface.EntityFramework.AlbumModel")
                        .WithMany("MusicModels")
                        .HasForeignKey("AlbumModelId");

                    b.HasOne("DataAccess.Interface.EntityFramework.ConvertedMusicModel", "ConvertedMusicModel")
                        .WithMany()
                        .HasForeignKey("ConvertedMusicModelId");
                });

            modelBuilder.Entity("DataAccess.Interface.EntityFramework.NoteModel", b =>
                {
                    b.HasOne("DataAccess.Interface.EntityFramework.ConvertedMusicModel")
                        .WithMany("Notes")
                        .HasForeignKey("ConvertedMusicModelId");
                });
        }
    }
}
