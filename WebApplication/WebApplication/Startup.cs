
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DTO;
using Faculty.EF;
using Faculty.Entities;
using Faculty.Interfaces;
using Faculty.Repositories;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services;

namespace WebApplication
{
    public class Startup
    {
         public Startup(IConfiguration configuration)
                {
                    Configuration = configuration;
                }
        
                public IConfiguration Configuration { get; }
        
                public void ConfigureServices(IServiceCollection services)
                {
                    services.AddControllersWithViews();
                    //AddAllGenericTypes(services,typeof(IRepository<>), new[]{typeof(ApplicationContext).GetTypeInfo().Assembly});
                    services.AddTransient<IStudentService, StudentService>();
                    services.AddTransient<ILecturerService, LecturerService>();
                    services.AddTransient<IAdminService, AdminService>();
                    services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
                    services.AddDbContext<ApplicationContext>(options => options.UseMySql("Host=localhost;Port=3306;Database=mydb_sharp;Username=tntrol;Password=password",
                        new MySqlServerVersion(new Version(8, 0, 11))));
                    
                    

                }
                
                public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                {
                    //loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
                    //var logger = loggerFactory.CreateLogger("FileLogger");
                    app.UseStaticFiles();
                    if (env.IsDevelopment())
                    {
                        //logger.LogInformation("Using developer exception page", null);
                        app.UseDeveloperExceptionPage();
                    }
                    else
                    {
                        app.UseExceptionHandler("/Item/Error");
                        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                        app.UseHsts();
                    }
        
                    app.UseHttpsRedirection();
                    app.UseStaticFiles();
        
                    app.UseRouting();
        
                    app.UseAuthorization();
        
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Index}/{action=Index}/{id?}");
                    });
        
        
        
                }
    }
}