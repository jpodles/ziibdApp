using Microsoft.EntityFrameworkCore;

namespace ziibdApp.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EmpDetailsView> EmpDetailsView { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<JobGrades> JobGrades { get; set; }
        public virtual DbSet<JobHistory> JobHistory { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "ZIIBD9");

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("COUNTRY_C_ID_PK");

                entity.ToTable("COUNTRIES");

                entity.Property(e => e.CountryId)
                    .HasColumnName("COUNTRY_ID")
                    .HasColumnType("CHAR(2)");

                entity.Property(e => e.CountryName)
                    .HasColumnName("COUNTRY_NAME")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RegionId)
                    .HasColumnName("REGION_ID")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("COUNTR_REG_FK");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("DEPT_ID_PK");

                entity.ToTable("DEPARTMENTS");

                entity.HasIndex(e => e.LocationId)
                    .HasName("DEPT_LOCATION_IX");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DEPARTMENT_ID")
                    .HasColumnType("NUMBER(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId)
                    .HasColumnName("LOCATION_ID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("MANAGER_ID")
                    .HasColumnType("NUMBER(6)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("DEPT_LOC_FK");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("DEPT_MGR_FK");
            });

            modelBuilder.Entity<EmpDetailsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EMP_DETAILS_VIEW");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CommissionPct)
                    .HasColumnName("COMMISSION_PCT")
                    .HasColumnType("NUMBER(2,2)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("COUNTRY_ID")
                    .HasColumnType("CHAR(2)");

                entity.Property(e => e.CountryName)
                    .HasColumnName("COUNTRY_NAME")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DEPARTMENT_ID")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EMPLOYEE_ID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.JobId)
                    .IsRequired()
                    .HasColumnName("JOB_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("JOB_TITLE")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId)
                    .HasColumnName("LOCATION_ID")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("MANAGER_ID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.RegionName)
                    .HasColumnName("REGION_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("NUMBER(8,2)");

                entity.Property(e => e.StateProvince)
                    .HasColumnName("STATE_PROVINCE")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("EMP_EMP_ID_PK");

                entity.ToTable("EMPLOYEES");

                entity.HasIndex(e => e.Email)
                    .HasName("EMP_EMAIL_UK")
                    .IsUnique();

                entity.HasIndex(e => e.JobId)
                    .HasName("EMP_JOB_IX");

                entity.HasIndex(e => e.ManagerId)
                    .HasName("EMP_MANAGER_IX");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EMPLOYEE_ID")
                    .HasColumnType("NUMBER(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommissionPct)
                    .HasColumnName("COMMISSION_PCT")
                    .HasColumnType("NUMBER(2,2)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DEPARTMENT_ID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate)
                    .HasColumnName("HIRE_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.JobId)
                    .IsRequired()
                    .HasColumnName("JOB_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId)
                    .HasColumnName("MANAGER_ID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PHONE_NUMBER")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("NUMBER(8,2)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("EMP_DEPT_FK");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_JOB_FK");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("EMP_MANAGER_FK");
            });

            modelBuilder.Entity<JobGrades>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("JOB_GRADES");

                entity.Property(e => e.GradeLevel)
                    .HasColumnName("GRADE_LEVEL")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.HighestSal)
                    .HasColumnName("HIGHEST_SAL")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.LowestSal)
                    .HasColumnName("LOWEST_SAL")
                    .HasColumnType("NUMBER");
            });

            modelBuilder.Entity<JobHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.StartDate })
                    .HasName("JHIST_EMP_ID_ST_DATE_PK");

                entity.ToTable("JOB_HISTORY");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("JHIST_DEPARTMENT_IX");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("JHIST_EMPLOYEE_IX");

                entity.HasIndex(e => e.JobId)
                    .HasName("JHIST_JOB_IX");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EMPLOYEE_ID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DEPARTMENT_ID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.JobId)
                    .IsRequired()
                    .HasColumnName("JOB_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.JobHistory)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("JHIST_DEPT_FK");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobHistory)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JHIST_EMP_FK");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobHistory)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JHIST_JOB_FK");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("JOB_ID_PK");

                entity.ToTable("JOBS");

                entity.Property(e => e.JobId)
                    .HasColumnName("JOB_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("JOB_TITLE")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MaxSalary)
                    .HasColumnName("MAX_SALARY")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.MinSalary)
                    .HasColumnName("MIN_SALARY")
                    .HasColumnType("NUMBER(6)");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("LOC_ID_PK");

                entity.ToTable("LOCATIONS");

                entity.HasIndex(e => e.City)
                    .HasName("LOC_CITY_IX");

                entity.HasIndex(e => e.CountryId)
                    .HasName("LOC_COUNTRY_IX");

                entity.HasIndex(e => e.StateProvince)
                    .HasName("LOC_STATE_PROVINCE_IX");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LOCATION_ID")
                    .HasColumnType("NUMBER(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId)
                    .HasColumnName("COUNTRY_ID")
                    .HasColumnType("CHAR(2)");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("POSTAL_CODE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.StateProvince)
                    .HasColumnName("STATE_PROVINCE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasColumnName("STREET_ADDRESS")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("LOC_C_ID_FK");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("REG_ID_PK");

                entity.ToTable("REGIONS");

                entity.Property(e => e.RegionId)
                    .HasColumnName("REGION_ID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.RegionName)
                    .HasColumnName("REGION_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("DEPARTMENTS_SEQ");

            modelBuilder.HasSequence("EMPLOYEES_SEQ");

            modelBuilder.HasSequence("LOCATIONS_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public void GetEmployeeCount()
        {
            var employeeCount = Employees.CountAsync();
            System.Console.WriteLine(employeeCount);
        }
    }
}
