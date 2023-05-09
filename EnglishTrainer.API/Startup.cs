using System;
using System.Data;
using System.Text;
using EnglishTrainer.API.Authentication;
using EnglishTrainer.Core.Application;
using EnglishTrainer.Core.Domain;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Features;
using EnglishTrainer.Core.Domain.Repositories;
using EnglishTrainer.Core.Infrastructure;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

namespace EnglishTrainer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));
            
            var jwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfiguration>();
            
            services.AddSingleton(jwtConfig);
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)),
                        ValidateLifetime = true
                    };
                });
            
            TranslationTrainerSettings settings = new TranslationTrainerSettings(5, 3, 4);
            
            RegisterDapperRepository(services);
            services.AddSingleton(settings);

            services.AddScoped<IExerciseFactory, ExerciseFactory>();
            services.AddScoped<ISetService, SetService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            
            services.AddSingleton<IJwtIssuer, JwtIssuer>();
            services.AddControllers();
            
            services.AddHangfire(config =>                 
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseDefaultTypeSerializer()
                    .UseMemoryStorage());
            services.AddHangfireServer();
        }

        private void RegisterDapperRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDbConnection>(
                serviceProvider => new NpgsqlConnection(GetPostgreSqlConnectionString()));
            serviceCollection.AddScoped<IUserRepository, PostgreSqlUserRepository>();
            serviceCollection.AddScoped<IWordsRepository, PostgreSqlWordsRepository>();
            serviceCollection.AddScoped<ISetRepository, PostgreSqlSetRepository>();
            serviceCollection.AddScoped<IRecommendedSetsRepository, PostgreSqlRecommendedSetsRepository>();
            serviceCollection.AddScoped<IStudiedSetsRepository, PostgreSqlStudiedSetsRepository>();
            serviceCollection.AddScoped<IExerciseWordsRepository, PostgreSqlExerciseWordsRepository>();
        }
        
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(
                options => options.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.UseHangfireDashboard();
            recurringJobManager.AddOrUpdate(
                "Statistics",
                () => serviceProvider.GetService<IStatisticsService>().UpdateSetStatistics(),
                "*/5 * * * *"
            );
            recurringJobManager.AddOrUpdate(
                "Recommendations",
                () => serviceProvider.GetService<IRecommendationService>().Generate(),
                "*/5 * * * *"
            );
        }
        
        private string GetSqlServerConnectionString()
        {
            return Configuration.GetValue<string>("SqlServerConnectionString");
        }

        private string GetPostgreSqlConnectionString()
        {
            return Configuration.GetValue<string>("PostgreSqlConnectionString");
        }
    }
}
