using System;
using System.Collections.Generic;

using Generics.Girls.Utils;
using Generics.Girls.HttpClients;
using Generics.Girls.HttpClients.Impl;
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
            services.AddCors();
            services.AddControllers();

            services
                .AddTransient<XmlReader>()
                .AddTransient<CsvReader>();

            services
                .AddSingleton<IGirlsBrokerHttpClient, GirlsBrokerHttpClient>();

            services
                .AddSingleton<IFileService, FileService>()
                .AddTransient((Func<IServiceProvider, Func<FileType, IFileReader>>)(serviceProvider => key =>
                {
                    var b =  GetFileReaderInstance(serviceProvider, key);
                    return b;
                }));

            services.AddHttpClient<GirlsBrokerHttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.WithOrigins("http://example.com").AllowAnyMethod()
            );
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IFileReader GetFileReaderInstance(IServiceProvider serviceProvider, FileType key)
        {
            return key switch
            {
                FileType.XML => serviceProvider.GetService<XmlReader>(),
                FileType.CSV => serviceProvider.GetService<CsvReader>(),
                _ => throw new KeyNotFoundException(),
            };
        }
    }
}
