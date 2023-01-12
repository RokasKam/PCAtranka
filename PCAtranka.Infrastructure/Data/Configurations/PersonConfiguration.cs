using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCAtranka.Domain.Entities;

namespace PCAtranka.Infrastructure.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(x => x.CreationDate).HasDefaultValueSql("DATE('now')");
        builder.Property(x => x.ModificationDate).HasDefaultValueSql("DATE('now')");
    }
}