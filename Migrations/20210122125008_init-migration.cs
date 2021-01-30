using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ziibdApp.Migrations
{
    public partial class initmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ZIIBD9");

            migrationBuilder.CreateSequence(
                name: "DEPARTMENTS_SEQ",
                schema: "ZIIBD9");

            migrationBuilder.CreateSequence(
                name: "EMPLOYEES_SEQ",
                schema: "ZIIBD9");

            migrationBuilder.CreateSequence(
                name: "LOCATIONS_SEQ",
                schema: "ZIIBD9");

            migrationBuilder.CreateTable(
                name: "JOB_GRADES",
                schema: "ZIIBD9",
                columns: table => new
                {
                    GRADE_LEVEL = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    LOWEST_SAL = table.Column<decimal>(type: "NUMBER", nullable: true),
                    HIGHEST_SAL = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JOBS",
                schema: "ZIIBD9",
                columns: table => new
                {
                    JOB_ID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    JOB_TITLE = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    MIN_SALARY = table.Column<int>(type: "NUMBER(6)", nullable: true),
                    MAX_SALARY = table.Column<int>(type: "NUMBER(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JOB_ID_PK", x => x.JOB_ID);
                });

            migrationBuilder.CreateTable(
                name: "REGIONS",
                schema: "ZIIBD9",
                columns: table => new
                {
                    REGION_ID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    REGION_NAME = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("REG_ID_PK", x => x.REGION_ID);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRIES",
                schema: "ZIIBD9",
                columns: table => new
                {
                    COUNTRY_ID = table.Column<string>(type: "CHAR(2)", nullable: false),
                    COUNTRY_NAME = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    REGION_ID = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COUNTRY_C_ID_PK", x => x.COUNTRY_ID);
                    table.ForeignKey(
                        name: "COUNTR_REG_FK",
                        column: x => x.REGION_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "REGIONS",
                        principalColumn: "REGION_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOCATIONS",
                schema: "ZIIBD9",
                columns: table => new
                {
                    LOCATION_ID = table.Column<int>(type: "NUMBER(6)", nullable: false),
                    STREET_ADDRESS = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    POSTAL_CODE = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    CITY = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    STATE_PROVINCE = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    COUNTRY_ID = table.Column<string>(type: "CHAR(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("LOC_ID_PK", x => x.LOCATION_ID);
                    table.ForeignKey(
                        name: "LOC_C_ID_FK",
                        column: x => x.COUNTRY_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "COUNTRIES",
                        principalColumn: "COUNTRY_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                schema: "ZIIBD9",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "NUMBER(6)", nullable: false),
                    FIRST_NAME = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    LAST_NAME = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    PHONE_NUMBER = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    HIRE_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    JOB_ID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    SALARY = table.Column<decimal>(type: "NUMBER(8,2)", nullable: true),
                    COMMISSION_PCT = table.Column<decimal>(type: "NUMBER(2,2)", nullable: true),
                    MANAGER_ID = table.Column<int>(type: "NUMBER(6)", nullable: true),
                    DEPARTMENT_ID = table.Column<int>(type: "NUMBER(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EMP_EMP_ID_PK", x => x.EMPLOYEE_ID);
                    table.ForeignKey(
                        name: "EMP_JOB_FK",
                        column: x => x.JOB_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "JOBS",
                        principalColumn: "JOB_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EMP_MANAGER_FK",
                        column: x => x.MANAGER_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                schema: "ZIIBD9",
                columns: table => new
                {
                    DEPARTMENT_ID = table.Column<int>(type: "NUMBER(6)", nullable: false),
                    DEPARTMENT_NAME = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    MANAGER_ID = table.Column<int>(type: "NUMBER(6)", nullable: true),
                    LOCATION_ID = table.Column<int>(type: "NUMBER(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DEPT_ID_PK", x => x.DEPARTMENT_ID);
                    table.ForeignKey(
                        name: "DEPT_LOC_FK",
                        column: x => x.LOCATION_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "LOCATIONS",
                        principalColumn: "LOCATION_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "DEPT_MGR_FK",
                        column: x => x.MANAGER_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JOB_HISTORY",
                schema: "ZIIBD9",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "NUMBER(6)", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    JOB_ID = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    DEPARTMENT_ID = table.Column<int>(type: "NUMBER(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JHIST_EMP_ID_ST_DATE_PK", x => new { x.EMPLOYEE_ID, x.START_DATE });
                    table.ForeignKey(
                        name: "JHIST_DEPT_FK",
                        column: x => x.DEPARTMENT_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "DEPARTMENTS",
                        principalColumn: "DEPARTMENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JHIST_EMP_FK",
                        column: x => x.EMPLOYEE_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JHIST_JOB_FK",
                        column: x => x.JOB_ID,
                        principalSchema: "ZIIBD9",
                        principalTable: "JOBS",
                        principalColumn: "JOB_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COUNTRIES_REGION_ID",
                schema: "ZIIBD9",
                table: "COUNTRIES",
                column: "REGION_ID");

            migrationBuilder.CreateIndex(
                name: "DEPT_LOCATION_IX",
                schema: "ZIIBD9",
                table: "DEPARTMENTS",
                column: "LOCATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENTS_MANAGER_ID",
                schema: "ZIIBD9",
                table: "DEPARTMENTS",
                column: "MANAGER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_DEPARTMENT_ID",
                schema: "ZIIBD9",
                table: "EMPLOYEES",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "EMP_EMAIL_UK",
                schema: "ZIIBD9",
                table: "EMPLOYEES",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EMP_JOB_IX",
                schema: "ZIIBD9",
                table: "EMPLOYEES",
                column: "JOB_ID");

            migrationBuilder.CreateIndex(
                name: "EMP_MANAGER_IX",
                schema: "ZIIBD9",
                table: "EMPLOYEES",
                column: "MANAGER_ID");

            migrationBuilder.CreateIndex(
                name: "JHIST_DEPARTMENT_IX",
                schema: "ZIIBD9",
                table: "JOB_HISTORY",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "JHIST_EMPLOYEE_IX",
                schema: "ZIIBD9",
                table: "JOB_HISTORY",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "JHIST_JOB_IX",
                schema: "ZIIBD9",
                table: "JOB_HISTORY",
                column: "JOB_ID");

            migrationBuilder.CreateIndex(
                name: "LOC_CITY_IX",
                schema: "ZIIBD9",
                table: "LOCATIONS",
                column: "CITY");

            migrationBuilder.CreateIndex(
                name: "LOC_COUNTRY_IX",
                schema: "ZIIBD9",
                table: "LOCATIONS",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "LOC_STATE_PROVINCE_IX",
                schema: "ZIIBD9",
                table: "LOCATIONS",
                column: "STATE_PROVINCE");

            migrationBuilder.AddForeignKey(
                name: "EMP_DEPT_FK",
                schema: "ZIIBD9",
                table: "EMPLOYEES",
                column: "DEPARTMENT_ID",
                principalSchema: "ZIIBD9",
                principalTable: "DEPARTMENTS",
                principalColumn: "DEPARTMENT_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "COUNTR_REG_FK",
                schema: "ZIIBD9",
                table: "COUNTRIES");

            migrationBuilder.DropForeignKey(
                name: "DEPT_LOC_FK",
                schema: "ZIIBD9",
                table: "DEPARTMENTS");

            migrationBuilder.DropForeignKey(
                name: "DEPT_MGR_FK",
                schema: "ZIIBD9",
                table: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "JOB_GRADES",
                schema: "ZIIBD9");

            migrationBuilder.DropTable(
                name: "JOB_HISTORY",
                schema: "ZIIBD9");

            migrationBuilder.DropTable(
                name: "REGIONS",
                schema: "ZIIBD9");

            migrationBuilder.DropTable(
                name: "LOCATIONS",
                schema: "ZIIBD9");

            migrationBuilder.DropTable(
                name: "COUNTRIES",
                schema: "ZIIBD9");

            migrationBuilder.DropTable(
                name: "EMPLOYEES",
                schema: "ZIIBD9");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS",
                schema: "ZIIBD9");

            migrationBuilder.DropTable(
                name: "JOBS",
                schema: "ZIIBD9");

            migrationBuilder.DropSequence(
                name: "DEPARTMENTS_SEQ",
                schema: "ZIIBD9");

            migrationBuilder.DropSequence(
                name: "EMPLOYEES_SEQ",
                schema: "ZIIBD9");

            migrationBuilder.DropSequence(
                name: "LOCATIONS_SEQ",
                schema: "ZIIBD9");
        }
    }
}
