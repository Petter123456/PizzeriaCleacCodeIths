using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Orders;
using PizzeriaCleacCodeIths.PricesCalculation;

namespace PizzeriaCleacCodeIths
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
            ConfigureSwagger(services); 
            services.AddControllers(x => x.AllowEmptyInputInBodyModelBinding = true);
            services.AddScoped<IOrder, Order>();
            services.AddScoped<ICalculateOrderPrice, CalculateOrderPrice>();
            services.AddScoped<IMenu, Menu>();
            services.AddScoped<IValidate, Validate>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc();
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders");
            });

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
