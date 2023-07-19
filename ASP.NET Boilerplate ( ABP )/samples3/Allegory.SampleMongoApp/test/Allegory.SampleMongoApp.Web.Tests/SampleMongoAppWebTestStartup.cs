using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Allegory.SampleMongoApp;

public class SampleMongoAppWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<SampleMongoAppWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
