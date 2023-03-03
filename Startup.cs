using GraphQLPractice.Configurations;
using GraphQLPractice.Data;
using GraphQLPractice.GraphQL.DataLoaders;
using GraphQLPractice.GraphQL.ObjectTypes;
using GraphQLPractice.UOW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLPractice
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
            // Adding GraphQLServer
            services.AddGraphQLServer()
                .AddQueryType<QueryObjectType>()
                .AddMutationType<MutationObjectType>()
                .AddDataLoader<FilterGadgetsByBrandDataLoader>();

            // Setting up DB
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("myConn"));
            //});

            services.AddPooledDbContextFactory<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("myConn"));
            });

            // Setting up AutoMapper
            services.AddAutoMapper(typeof(MapperInitializer));

            // Setting up UnitOfWork DI
            //services.AddTransient<IUnitOfWork, UnitOfWork>(); // this isn't useable with [scopedService] dbContext.

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLPractice", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLPractice v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // enabling graphql endpoint support
                endpoints.MapGraphQL();

                endpoints.MapControllers();
            });
        }
    }
}
