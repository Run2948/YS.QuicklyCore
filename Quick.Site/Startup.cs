using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quick.Controllers.Filters;
using Quick.EFCore;

namespace Quick.Site
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MssqlConnection")));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlConnection")
                    /* further MySQL option configurations go here https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql
                    , mysqlOptions =>
                    {        
                        mysqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql);  //  replace with your Server Version and Type                      
                        //.DisableBackslashEscaping();   // support SQL mode NO_BACKSLASH_ESCAPES 
                        //.CharSetBehavior(CharSetBehavior.AppendToAllColumns)
                        //.AnsiCharSet(CharSet.Latin1)
                        //.UnicodeCharSet(CharSet.Utf8mb4);
                    }
                    */
                )
            );


            //反射加载接口实现类，批量注入
            Assembly assembly = Assembly.Load("Quick.Domain");
            foreach (var implement in assembly.GetTypes())
            {
                Type[] interfaceType = implement.GetInterfaces();
                foreach (var service in interfaceType)
                {
                    services.AddTransient(service, implement);
                }
            }

            services.AddMvc();

            //Policy-based authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy =>
                    policy.Requirements.Add(new RoleRequirement("Administrator")));
                options.AddPolicy("Instructor", policy =>
                    policy.Requirements.Add(new RoleRequirement("Instructor")));
                options.AddPolicy("Student", policy =>
                    policy.Requirements.Add(new RoleRequirement("Student")));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Secret/Login");
                options.LoginPath = new PathString("/Secret/Login");
                options.LogoutPath = new PathString("/Secret/Logout");
            });

            services.AddSingleton<IAuthorizationHandler, RoleHandler>();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Secret/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Secret}/{action=Login}/{id?}");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
