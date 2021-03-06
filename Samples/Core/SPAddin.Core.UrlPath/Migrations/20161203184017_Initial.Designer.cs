﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SPAddin.Core.UrlPath.DB;

namespace SPAddin.Core.UrlPath.Migrations
{
    [DbContext(typeof(AddInContext))]
    [Migration("20161203184017_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SPAddin.Core.UrlPath.Entities.Host", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hash");

                    b.Property<string>("ShortHandUrl");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Hosts");
                });
        }
    }
}
