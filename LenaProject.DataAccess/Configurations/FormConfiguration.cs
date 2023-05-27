using LenaProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LenaProject.DataAccess.Configurations
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Forms).HasForeignKey(x => x.UserId);
        }
    }
}
