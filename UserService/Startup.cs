using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UserService.Data;
using UserService.Shared.Interface;
using UserService.Buisness;
using Microsoft.EntityFrameworkCore;
using OpenTracing;
using System.Reflection;
using Jaeger.Samplers;
using OpenTracing.Util;
using Jaeger.Senders.Thrift;
using Jaeger;
using Jaeger.Reporters;

namespace UserService
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

            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDBConnection")));
 
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserDal, UserDal>();

            services.AddSingleton<ITracer>(serviceProvider =>
            {
                string serviceName = Assembly.GetEntryAssembly().GetName().Name;

                ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ISampler sampler = new ConstSampler(sample: true);
                var reporter = new RemoteReporter.Builder().WithLoggerFactory(loggerFactory)
                .WithSender(new UdpSender("jaeger-agent", 6831, 0)).Build();

                ITracer tracer = new Tracer.Builder(serviceName).WithLoggerFactory(loggerFactory).
                WithSampler(sampler).WithReporter(reporter).Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

            services.AddOpenTracing();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserDbContext userDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            userDbContext.Database.EnsureCreated();
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
