using Autofac;
using Autofac.Extensions.DependencyInjection;
using FlakeyBit.DigestAuthentication.AspNetCore;
using FlakeyBit.DigestAuthentication.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Root.Helpers;
using Serilog;
using System;

namespace EWallentApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public Autofac.IContainer Container { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddCors();
            services.AddMvc();

            //Регистрация классов, каторые доёт возможность изпользовать Digest Auth
            services.AddScoped<IUsernameHashedSecretProvider, TrivialUserIdHashedSecretProvider>();
            services.AddAuthentication("Digest")
                    .AddDigestAuthentication(DigestAuthenticationConfiguration.Create("ElectronWalletSecret", "some-realm", 60, true, 20));

            services.AddControllers().
                AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddSingleton(Log.Logger); //For logging
            
            

            var builder = new ContainerBuilder();

            //Autofac даёт возможность автоматической регистрации сервисов
            EWalletService.ServicesStart.Builder(builder);
            builder.Populate(services);
            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseRouting();

            app.UseCors(builder => builder
               .WithOrigins("*")
               .AllowAnyMethod()
               .AllowAnyHeader());


            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            if (app.ApplicationServices.GetService<IHttpContextAccessor>() != null)
                HttpContextHelper.Accessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            
        }
    }
}
