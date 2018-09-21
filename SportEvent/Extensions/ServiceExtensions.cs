using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using SportEvent.Data;
using SportEvent.Data.Repository.Interfaces;
using SportEvent.Helper;
using SportEvent.Helper.Interfaces;
using SportEvent.Bll.Interfaces;
using SportEvent.Bll;

namespace SportEvent.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Dependency Injection Repository and UnitOfWork.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="Configuration">The configuration from settinfile.</param>
        public static void ConfigureRepository(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddEntityFrameworkSqlServer()
             .AddDbContext<DbContext>(options =>
              options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddTransient<IUnitOfWork, SeUnitOfWork>();
        }

        /// <summary>
        /// Dependency Injection Class Business Logic Layer.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public static void ConfigureBll(this IServiceCollection services)
        {
            services.AddScoped<IEvent, Event>();
        }

        /// <summary>
        /// Add Singletion Logger Class.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Add Middleware when request bein and end.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<Middleware>();
        }

        /// <summary>
        /// Configure Basic Authentication
        /// </summary>
        /// <param name="services">The service collection.</param>
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddScoped<BasicAuthAttribute>();
        }

    }
}
