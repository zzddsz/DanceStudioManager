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
            services.AddLogging();
            var connection = "server=localhost;database=studio;user=root;password=";

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(connection));
            services.AddAutoMapper(cfg => { }, typeof(DanceClassProfile).Assembly);
            services.AddScoped<DanceClassRepository>();
            services.AddScoped<DanceClassValidator>();
            services.AddScoped<DanceClassService>();
            services.AddScoped<DanceClassController>();
            services.AddTransient<Form1>();
            services.AddTransient<FormAddEdit>();

            var provider = services.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                ctx.Database.EnsureCreated();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(provider.GetRequiredService<Form1>());
        }
    }
}
