using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PersonalOrganizer.Domain;
using PersonalOrganizer.WebApi.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PersonalOrganizer.Domain.DataAccess;
using PersonalOrganizer.Domain.Repos.Notes;

namespace PersonalOrganizer.WebApi
{
    public class Startup
    {
         readonly string _allowAllCorsOrigin = "defaul";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DataBaseSettings>(Configuration.GetSection(nameof(DataBaseSettings)));
            var dataBaseSettings =
                services.BuildServiceProvider().GetRequiredService<IOptions<DataBaseSettings>>().Value;
            var connectionString =dataBaseSettings.PgConnectionString();
            
            services.AddDbContext<TrackerDbContext>(options => options.UseNpgsql(connectionString));
            
            //add repos 
            services.AddScoped<INotes, NotesRepository>();
            services.AddScoped<IToDo, ToDoRepository>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "PersonalOrganizer.WebApi", Version = "v1"});
            });
            
            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: _allowAllCorsOrigin, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           /* if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalOrganizer.WebApi v1"));
            }*/
           app.UseDeveloperExceptionPage();
           app.UseSwagger();
           app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalOrganizer.WebApi v1"));


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_allowAllCorsOrigin);
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}