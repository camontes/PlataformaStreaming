using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SampleAPI.Auth;
using SampleAPI.Domain.Behaviors;
using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain.Managers;
using SampleAPI.Domain.Repositories;
using SampleAPI.Infrastructure;
using SampleAPI.Infrastructure.Repositories;
using SampleAPI.Queries;
using Swashbuckle.AspNetCore.Swagger;

namespace SampleAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Auth0 definition
            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:ApiIdentifier"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });

            // Roles
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin:api", policy => policy.Requirements.Add(new HasScopeRequirement("admin:api", domain)));
                options.AddPolicy("teacher:api", policy => policy.Requirements.Add(new HasScopeRequirement("teacher:api", domain)));
            });

            // register the scope authorization handler
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();



            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add SQL Server
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                serverOptions => serverOptions.MigrationsAssembly("SampleAPI"))
            );

            // Add other components

            /// User
            services.AddScoped<IUserBehavior, UserBehavior>();
            services.AddScoped<IUserQueries, UserQueries>();
            services.AddScoped<IUserRepository, UserRepository>();

            /// Category
            services.AddScoped<ICategoryBehavior, CategoryBehavior>();
            services.AddScoped<ICategoryQueries, CategoryQuerys>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            /// Course

            services.AddScoped<ICourseQueries, CourseQuerys>();
            services.AddScoped<ICourseBehavior, CourseBehavior>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            // UserCourse

            services.AddScoped<IUserCourseQueries, UserCourseQuerys>();
            services.AddScoped<IUserCourseBehavior, UserCourseBehavior>();
            services.AddScoped<IUserCourseRepository, UserCourseRepository>();

            // Subjects

            services.AddScoped<ISubjectQueries, SubjectQuerys>();
            services.AddScoped<ISubjectBehavior, SubjectBehavior>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            // Contents

            services.AddScoped<IContentQueries, ContentQuerys>();
            services.AddScoped<IContentBehavior, ContentBehavior>();
            services.AddScoped<IContentRepository, ContentRepository>();

            // Options

            services.AddScoped<IOptionQueries, OptionQuerys>();
            services.AddScoped<IOptionBehavior, OptionBehavior>();
            services.AddScoped<IOptionRepository, OptionRepository>();

            // Questions

            services.AddScoped<IQuestionQueries, QuestionQuerys>();
            services.AddScoped<IQuestionBehavior, QuestionBehavior>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            // UserContents
            services.AddScoped<IUserContentQueries, UserContentQueries>();
            services.AddScoped<IUserContentBehavior, UserContentBehavior>();
            services.AddScoped<IUserContentRepository, UserContentRepository>();

            // Add Automapper
            services.AddAutoMapper();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SampleAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleAPI V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();

            // Ensure db migrations
            UpdateDatabase(app);

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
