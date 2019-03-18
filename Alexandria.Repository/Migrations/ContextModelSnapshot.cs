﻿// <auto-generated />
using System;
using Alexandria.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alexandria.Repository.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alexandria.Model.Avatar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<string>("Line");

                    b.Property<string>("Literary_genre")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Avatar");
                });

            modelBuilder.Entity("Alexandria.Model.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Authors")
                        .IsRequired();

                    b.Property<DateTime>("Date_published");

                    b.Property<string>("Edition")
                        .IsRequired();

                    b.Property<string>("Editora")
                        .IsRequired();

                    b.Property<string>("ISBN")
                        .IsRequired();

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<string>("Literary_genre")
                        .IsRequired();

                    b.Property<int>("Pages");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Title_long");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Alexandria.Model.Bookcase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookcase");
                });

            modelBuilder.Entity("Alexandria.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AvatarId");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("CPF")
                        .IsRequired();

                    b.Property<int>("Coin");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Alexandria.Model.Bookcase", b =>
                {
                    b.HasOne("Alexandria.Model.Book", "Book")
                        .WithMany("Bookcase")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Alexandria.Model.User", "User")
                        .WithMany("Bookcase")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Alexandria.Model.User", b =>
                {
                    b.HasOne("Alexandria.Model.Avatar", "Avatar")
                        .WithMany("Users")
                        .HasForeignKey("AvatarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
