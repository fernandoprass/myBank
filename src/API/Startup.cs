using API.Contracts;
using API.Contracts.Business;
using API.Implementation.Business;
using API.Models;
using API.Repository;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            ConfigureDependencyInjection(services);
        }

        /// <summary>
        /// The Database connection configuration
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureDatabaseConnection(IServiceCollection services)
        {
            throw new NotImplementedException();
            //string connection = Configuration.GetConnectionString("MyBankDB");
            //services.AddDbContext<MyBankContext>(o => o.UseSqlServer(connection));
        }

        /// <summary>
        /// The Dependency Injection configuration
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
