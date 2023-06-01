using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DogsHouse.Core.Models;

namespace DogsHouse.Data.Configurations
{
    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
