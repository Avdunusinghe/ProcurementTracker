using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Domain.Repositories.Command;
using ProcurementTracker.Domain.Repositories.Command.Base;
using ProcurementTracker.Domain.Repositories.Query;
using ProcurementTracker.Domain.Repositories.Query.Base;
using ProcurementTracker.Infrastructure.Data;
using ProcurementTracker.Infrastructure.Interceptors;
using ProcurementTracker.Infrastructure.Repositories.Command;
using ProcurementTracker.Infrastructure.Repositories.Command.Base;
using ProcurementTracker.Infrastructure.Repositories.Query;
using ProcurementTracker.Infrastructure.Repositories.Query.Base;
using ProcurementTracker.Infrastructure.Services;

namespace ProcurementTracker.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ProcurementTrackerContext>(options =>
                    options.UseInMemoryDatabase("DemoDb"));
            }
            else
            {
                services.AddDbContext<ProcurementTrackerContext>(options =>
                {
                    var connectionString = configuration.GetConnectionString("DefaultConnection");
                    options.UseSqlServer(connectionString);
                });
            }

            services.AddTransient<IProcurementTrackerContext>(provider => provider.GetRequiredService<ProcurementTrackerContext>());

            services.AddTransient<ProcurementTrackerContextInitialiser>();

            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<IUserQueryRepository, UserQueryRepository>();
            services.AddTransient<ISupplierQueryRepository, SupplierQueryRepository>();
            services.AddTransient<IOrderQueryRepository, OrderQueryRepository>();
            services.AddTransient<IProductQueryRepository, ProductQueryRepository>();

            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<IUserCommandRepository, UserCommandRepository>();
            services.AddTransient<IOrderCommandRepository, OrderCommandRepository>();


            services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMasterDataService, MasterDataService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
