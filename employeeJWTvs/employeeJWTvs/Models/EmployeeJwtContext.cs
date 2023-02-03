using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace employeeJWTvs.Models;

public partial class EmployeeJwtContext : DbContext
{
    public EmployeeJwtContext()
    {
    }

    public EmployeeJwtContext(DbContextOptions<EmployeeJwtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeedetailJwt> EmployeedetailJwts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TL217;Initial Catalog=employeeJWT;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeedetailJwt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("employeedetailJwt");

            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FristName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fristName");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("jobTitle");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Office)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("office");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PreferredName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("preferredName");
            entity.Property(e => e.SkypeId).HasColumnName("skypeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
