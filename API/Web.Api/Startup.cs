using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;
using Web.AppCore.Service;
using Web.Caching;
using Web.Infrastructure.Repository;

namespace Web.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web.Api", Version = "v1", Description = "APIs Web Nội Thất" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
                   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidAudience = Configuration["Jwt:Audience"],
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                   };
               });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.AddScoped(typeof(IContactRepository), typeof(ContactRepository));
            services.AddScoped(typeof(IContactService), typeof(ContactService));

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            services.AddScoped(typeof(IOrderDetailRepository), typeof(OrderDetailRepository));
            services.AddScoped(typeof(IOrderDetailService), typeof(OrderDetailService));

            services.AddScoped(typeof(IProductCategoryRepository), typeof(ProductCategoryRepository));
            services.AddScoped(typeof(IProductCategoryService), typeof(ProductCategoryService));

            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));

            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IProductService), typeof(ProductService));

            services.AddScoped(typeof(INewsRepository), typeof(NewsRepository));
            services.AddScoped(typeof(INewsService), typeof(NewsService));

            services.AddScoped(typeof(IRecruitmentRepository), typeof(RecruitmentRepository));
            services.AddScoped(typeof(IRecruitmentService), typeof(RecruitmentService));

            services.AddScoped(typeof(IProjectRepository), typeof(ProjectRepository));
            services.AddScoped(typeof(IProjectService), typeof(ProjectService));

            //services.AddScoped(typeof(ICartService), typeof(CartService));

            //RedisCacheOptions redisOption = Configuration.GetSection(nameof(RedisCacheOptions)).Get<RedisCacheOptions>();
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = redisOption.Configuration;
            //    options.InstanceName = redisOption.InstanceName;
            //    options.ConfigurationOptions = redisOption.ConfigurationOptions;
            //});
            //services.AddSingleton<IRedisCached, RedisCahed>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web.Api v1"));
            }
            // Hook in the global error-handling middleware
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
