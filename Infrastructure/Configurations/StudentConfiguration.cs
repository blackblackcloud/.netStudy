using DemoApi.domin.entities;
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
        builder.Property("_passWordHash");
        builder.Property(s => s.Remark).HasField("_remark");//只读，从数据库里取值，不能修改
        builder.Ignore(s=>s.Tag); //不映射到数据库中

        builder.HasOne(s => s.Teacher)
            .WithMany(t => t.Students)
            .HasForeignKey(s=>s.TeacherId)
            .OnDelete(DeleteBehavior.SetNull);   
           
    }
}