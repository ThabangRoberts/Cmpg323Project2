﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CmpgProject2.Migrations
{
    public partial class OwnerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationX",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(nullable: true),
                    EmployeeNumber = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    attrition = table.Column<string>(nullable: true),
                    BusinessTravel = table.Column<string>(nullable: true),
                    DailyRate = table.Column<int>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    DistanceFromHome = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    EducationField = table.Column<string>(nullable: true),
                    EmployeeCount = table.Column<string>(nullable: true),
                    EnvironmentSatisfaction = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    HourlyRate = table.Column<int>(nullable: false),
                    JobInvolvement = table.Column<string>(nullable: true),
                    JobLevel = table.Column<string>(nullable: true),
                    JobRole = table.Column<string>(nullable: true),
                    JobSatisfaction = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    MonthlyIncome = table.Column<int>(nullable: false),
                    MonthlyRate = table.Column<int>(nullable: false),
                    NumCompaniesWorked = table.Column<string>(nullable: true),
                    Over18 = table.Column<string>(nullable: true),
                    OverTime = table.Column<string>(nullable: true),
                    PercentSalaryHike = table.Column<int>(nullable: false),
                    PerformanceRating = table.Column<int>(nullable: false),
                    RelationshipSatisfaction = table.Column<string>(nullable: true),
                    StandardHours = table.Column<int>(nullable: false),
                    StockOptionLevel = table.Column<string>(nullable: true),
                    TotalWorkingYears = table.Column<string>(nullable: true),
                    TrainingTimesLastYear = table.Column<string>(nullable: true),
                    WorkLifeBalance = table.Column<string>(nullable: true),
                    YearsAtCompany = table.Column<string>(nullable: true),
                    YearsInCurrentRole = table.Column<string>(nullable: true),
                    YearsSinceLastPromotion = table.Column<string>(nullable: true),
                    YearsWithCurrManager = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationX", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationX");
        }
    }
}
