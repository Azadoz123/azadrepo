﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Allegory.SampleMongoApp.MongoDB;

[ConnectionStringName("Default")]
public class SampleMongoAppMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }


}
