using System;
using System.Collections.Generic;

using Generics.Girls.Utils;
using Generics.Girls.HttpClients;
using Generics.Girls.Services;
using Generics.Girls.Services.Impl;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Generics.Girls
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services
                .AddTransient<XmlReaderService>()
                .AddTransient<CsvReaderService>();

            services
                .AddSingleton<IFileService, FileService>()
                .AddTransient<Func<FileType, IFileReaderService>>(serviceProvider => key =>
                    {
                        switch (key)
                        {
                            case FileType.XML:
                                return serviceProvider.GetService<XmlReaderService>();
                            case FileType.CSV:
                                return serviceProvider.GetService<CsvReaderService>();
                            default:
                                throw new KeyNotFoundException();
                        }
                    }
                );

            services.AddHttpClient<IGirlsBrokerHttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
