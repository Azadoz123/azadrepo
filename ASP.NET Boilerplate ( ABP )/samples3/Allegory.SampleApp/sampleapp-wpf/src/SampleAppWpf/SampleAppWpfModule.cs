﻿using Allegory.SampleApp;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SampleAppWpf;

[DependsOn(typeof(AbpAutofacModule), typeof(SampleAppHttpApiClientModule),typeof(AbpHttpClientIdentityModelModule)]
public class SampleAppWpfModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton<MainWindow>();
    }
}
