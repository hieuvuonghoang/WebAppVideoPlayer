using FileServiceAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FileServiceAPI.Models;
using FileServiceAPI.Middlewares;

namespace FileServiceAPI
{
    public class Startup
    {
        readonly string _myPolicyCors = "_myPolicyCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<LinkAPI>(Configuration.GetSection("LinkAPI"));

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IMimeService, MimeService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: _myPolicyCors,
                    builder =>
                    {
                        builder
                        //.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed(x => true);
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(_myPolicyCors);

            //app.UseMiddleware<RequestMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("eNPTMap.Api");
                });
            });
        }
    }
}
