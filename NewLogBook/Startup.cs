using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLogBook.AppContext;
using NewLogBook.Entities;
using NewLogBook.Models;
using NewLogBook.Models.Ratings;
using NewLogBook.Repositories;
using NewLogBook.Repositories.interfaces;

namespace NewLogBook
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IFacultieRepository, FacultyRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IMarkRepository, MarkRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ITeacherSubjectRepository, TeacherSubjectRepository>();
            services.AddTransient<RatingStudents>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
