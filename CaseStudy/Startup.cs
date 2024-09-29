using CaseStudy.Data;
using CaseStudy.Entities;
using CaseStudy.Services;
using CaseStudy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CaseStudy
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // In-Memory Database Configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TransactionDb"));

            // Swagger Configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // Dependency Injection
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IBank, Akbank>();
            services.AddScoped<IBank, Garanti>();
            services.AddScoped<IBank, YapiKredi>();
            services.AddScoped<BankServiceFactory>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Swagger Middleware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
