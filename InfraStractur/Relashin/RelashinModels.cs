using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace InfraStractur.Relashin
{
    internal static class RelashinModels
    {
        public static void DepartmintAndCategori(ModelBuilder builder)
        {
            builder.Entity<Departmint>()
                .HasMany(c => c.categories)
                .WithOne(d => d.departmint)
                .HasForeignKey(c => c.departmintId);
        }
    }
}
