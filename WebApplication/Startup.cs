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
using TranslationTrainer;
using TranslationTrainer.Application;
using TranslationTrainer.Domain;
using TranslationTrainer.Infrastructure;

namespace WebApplication
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
            TranslationTrainerSettings settings = new TranslationTrainerSettings(5, 3);
            
            services.AddSingleton<IWordsRepository, WordsRepository>();
            services.AddSingleton<IExerciseRepository, ExerciseRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton(settings);
            services.AddSingleton<IExerciseFactory, ExerciseFactory>();
            services.AddSingleton<IExerciseFinisher, ExerciseFinisher>();
            services.AddSingleton<IExerciseService, ExerciseService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}