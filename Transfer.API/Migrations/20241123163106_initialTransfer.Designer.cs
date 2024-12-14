﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transfer.API.Model;

#nullable disable

namespace Transfer.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241123163106_initialTransfer")]
    partial class initialTransfer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Transfer.API.Model.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AccountHolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Transfer.API.Model.TransferRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ReceiverAccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReceiverId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("SenderAccountId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverAccountId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderAccountId");

                    b.ToTable("TransactionRequests");
                });

            modelBuilder.Entity("Transfer.API.Model.TransferRequest", b =>
                {
                    b.HasOne("Transfer.API.Model.Account", "ReceiverAccount")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("ReceiverAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Transfer.API.Model.Account", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Transfer.API.Model.Account", "SenderAccount")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("ReceiverAccount");

                    b.Navigation("SenderAccount");
                });

            modelBuilder.Entity("Transfer.API.Model.Account", b =>
                {
                    b.Navigation("ReceivedTransactions");

                    b.Navigation("SentTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}