using Env.Demo.Books;
using Env.Demo.Campaigns;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Env.Demo.EntityFrameworkCore
{
    public static class DemoDbContextModelCreatingExtensions
    {
        public static void ConfigureDemo(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Book>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "Books",
                          DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });

            builder.Entity<Campaign>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "Campaigns",
                          DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Subject).IsRequired().HasMaxLength(128);
            });

            builder.Entity<CampaignItem>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "CampaignItems",
                          DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                b.Property(x => x.Email).IsRequired().HasMaxLength(128);
                b.Property(x => x.IsSent).IsRequired();
                b.Property(x => x.CampaignId).IsRequired();

            });


            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(DemoConsts.DbTablePrefix + "YourEntities", DemoConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}