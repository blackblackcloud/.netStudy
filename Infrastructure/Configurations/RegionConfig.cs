using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoApi.domin.entities;
class RegionConfig :IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(r => r.Id);

        builder.OwnsOne(r => r.Area, nb =>
        {
            nb.Property(e=>e.Unit)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        builder.Property(r => r.Level)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.OwnsOne(r => r.Location);

        builder.OwnsOne(r => r.Name, nb =>
        {
            nb.Property(e => e.Chinese)
                .HasMaxLength(20)
                .IsUnicode(true);
            nb.Property(e => e.English)
                .HasMaxLength(20)
                .IsUnicode(false);
        });


    }
}