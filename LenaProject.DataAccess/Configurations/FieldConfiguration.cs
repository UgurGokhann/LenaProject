using LenaProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LenaProject.DataAccess.Configurations
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.Property(x => x.Required).IsRequired();
            builder.Property(x => x.DataType).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasOne(x=>x.Form).WithMany(x=>x.Fields).HasForeignKey(x=>x.FormId);


        }
    }
}
