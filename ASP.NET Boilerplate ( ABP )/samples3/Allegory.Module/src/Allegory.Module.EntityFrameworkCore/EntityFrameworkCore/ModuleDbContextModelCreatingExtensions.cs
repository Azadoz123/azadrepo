using Allegory.Module.Customers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Allegory.Module.EntityFrameworkCore;

public static class ModuleDbContextModelCreatingExtensions
{
    public static void ConfigureModule(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Customer>(b =>
        {
            b.ToTable(ModuleDbProperties.DbTablePrefix + "Customers", ModuleDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.Property(a => a.Name)
            .HasMaxLength(CustomerConsts.MaxNameLength)
            .IsRequired();
            b.Property(a => a.Surname)
            .HasMaxLength(CustomerConsts.MaxSurnameLength)
            .IsRequired();

            b.OwnsOne(a => a.Address);
            b.HasMany(a => a.ContactInformations)
            .WithOne()
            .HasForeignKey(f => f.CustomerId);

            b.HasOne<CustomerGroup>()
            .WithMany()
            .HasForeignKey(a => a.CustomerGroupId);
        });

        builder.Entity<ContactInformation>(b =>
        {
            b.ToTable(ModuleDbProperties.DbTablePrefix + "ContactInformations", ModuleDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.HasKey(k => new { k.CustomerId, k.Name });
            b.Property(a => a.Name)
            .HasMaxLength(CustomerConsts.MaxNameLength)
            .IsRequired();

            b.Property(a=> a.Value)
            .HasMaxLength (CustomerConsts.MaxSurnameLength) 
            .IsRequired();
        });

        builder.Entity<CustomerGroup>(b =>
        {
            b.ToTable(ModuleDbProperties.DbTablePrefix + "CustomerGroups", ModuleDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.Property(a => a.Code)
            .HasMaxLength(CustomerGroupConstants.MaxCodeLength)
            .IsRequired();
            b.Property(a=>a.Description)
            .HasMaxLength(CustomerGroupConstants.MaxDescriptionLength) 
            .IsRequired();
        });

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(ModuleDbProperties.DbTablePrefix + "Questions", ModuleDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
