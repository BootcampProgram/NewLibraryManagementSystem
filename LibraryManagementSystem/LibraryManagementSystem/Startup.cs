using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.DataSource;
using LMS.DataSource.Interfaces;
using LMS.DataSource.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem
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


            string SQLConnectionString = Configuration["connectionString:LMSDbConnectionString"];
            services.AddDbContext<AppDbContext>(a => a.UseSqlServer(SQLConnectionString));

            services.AddScoped<IStudentInterface, StudentRepository>();
            services.AddScoped<IReservationInterface, ReservationRepository>();
            services.AddScoped<IWishListInterface, WishListRepository>();
            services.AddScoped<IPublisherInterface, PublisherRepository>();
            services.AddScoped<ILibrarianInterface, LibrarianRepository>();
            services.AddScoped<IUserInterface, UserRepository>();
            services.AddScoped<IGenreInterface, GenreRepository>();
            services.AddScoped<IBookIdentificationInterface, BookIdentificationRepository>();
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
