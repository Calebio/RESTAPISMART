using Elasticsearch.Net;
using Elasticsearch.Net.Aws;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RESTAPISMART.Data;
using RESTAPISMART.Repository.Interface;
using RESTAPISMART.Repository.Repo;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPISMART
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", configuration.GetSection("AWS:AccessKey").Value);
            Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", configuration.GetSection("AWS:SecretKey").Value);
            Environment.SetEnvironmentVariable("AWS_REGION", configuration.GetSection("AWS:Region").Value);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration.GetSection("AWS:ElasticUrl").Value))
                {
                    ModifyConnectionSettings = conn =>
                    {
                        var httpConnection = new AwsHttpConnection(configuration.GetSection("AWS:Region").Value);
                        var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("AWS:ElasticUrl").Value));
                        var conf = new ConnectionConfiguration(pool, httpConnection);
                        return conf;
                    },
                    IndexFormat = "",
                })
                .CreateLogger();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            
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
