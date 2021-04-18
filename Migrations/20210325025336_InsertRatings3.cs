﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLibrary.Migrations
{
    public partial class InsertRatings3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine("Files", "SQL", @"6-3-InsertRatings.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from usermovies where id >= 30000 and id < 40000");
        }
    }
}
