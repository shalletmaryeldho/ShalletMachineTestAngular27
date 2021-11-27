using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationTravel.Models
{
    public partial class DBTravelContext : DbContext
    {
        public DBTravelContext()
        {
        }

        public DBTravelContext(DbContextOptions<DBTravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<RequestTable> RequestTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SHALLETMARY\\SQLEXPRESS; Initial Catalog=DBTravel; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F8E365E331");

                entity.Property(e => e.LId)
                    .HasColumnName("l_id")
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("projectId")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.ProjectName)
                    .HasColumnName("projectName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Registra__1299A861F0F572B6");

                entity.Property(e => e.EmpId)
                    .HasColumnName("emp_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId)
                    .HasColumnName("l_id")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(5, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__Registrati__l_id__2B3F6F97");
            });

            modelBuilder.Entity<RequestTable>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__RequestT__E3C5DE31D2502844");

                entity.Property(e => e.RequestId)
                    .HasColumnName("requestId")
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CauseTravel)
                    .HasColumnName("causeTravel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.EmpId)
                    .HasColumnName("emp_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("date");

                entity.Property(e => e.Mode)
                    .HasColumnName("mode")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoDays)
                    .HasColumnName("noDays")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("projectId")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.RequestTable)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__RequestTa__emp_i__300424B4");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.RequestTable)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__RequestTa__proje__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
