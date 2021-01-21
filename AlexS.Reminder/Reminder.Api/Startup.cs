using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reminder.Contracts.Data.Common.Domain;
using Reminder.Contracts.Data.Reminders.Domain;
using Reminder.Contracts.Data.Reminders.Query;
using Reminder.Contracts.Svc.Auth;
using Reminder.Contracts.Svc.Reminders;
using Reminder.Data.Reminders;
using Reminder.Svc.Auth;
using Reminder.Svc.Reminders;

namespace Reminder.Api
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

            services.AddScoped<IReminderDomainRepository, ReminderRepositoryStub>();
            services.AddScoped<IUnitOfWork, UnitOfWorkStub>();

            services.AddScoped<IReminderQueryRepository, ReminderRepositoryStub>();

            services.AddScoped<IAuthSvc, AuthSvcStub>();

            services.AddScoped<IRemindersSvc, RemindersSvc>();
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
