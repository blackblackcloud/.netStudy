using DemoApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoApi.Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.TeacherId);
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(40);

        builder.HasOne(s => s.Teacher)
            .WithMany(t => t.Students)
            .HasForeignKey(s=>s.TeacherId)
            .OnDelete(DeleteBehavior.SetNull);
           
    }
}