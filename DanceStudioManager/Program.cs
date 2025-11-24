using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DanceStudio.Repository.Data;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.Mappings;
using DanceStudio.Service.Services;
using DanceStudio.Service.Validators;
using DanceStudioManager.Controllers;
using System.Windows.Forms;

namespace DanceStudioManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // ?? REGISTRA O LOGGER NECESSÁRIO PARA O MySQL E EF CORE
            services.AddLogging();

            // CONEXÃO
            var connection = "server=localhost;database=studio;user=root;password=";

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(connection));

            // AUTO MAPPER
            services.AddAutoMapper(cfg => { }, typeof(DanceClassProfile).Assembly);

            // REPOSITORY
            services.AddScoped<DanceClassRepository>();

            // VALIDATOR
            services.AddScoped<DanceClassValidator>();

            // SERVICE
            services.AddScoped<DanceClassService>();

            // CONTROLLER
            services.AddScoped<DanceClassController>();

            // FORMS
            services.AddTransient<Form1>();
            services.AddTransient<FormAddEdit>();

            var provider = services.BuildServiceProvider();

            // CRIA O BANCO SE NECESSÁRIO
            using (var scope = provider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                ctx.Database.EnsureCreated();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<Form1>());
        }
    }
}
