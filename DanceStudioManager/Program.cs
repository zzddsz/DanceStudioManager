using AutoMapper;
using DanceStudio.Repository.Data;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.Mappings;
using DanceStudio.Service.Services;
using DanceStudio.Service.Validators;
using DanceStudioManager.Controllers;
using DanceStudioManager.Forms;
using DanceStudioManager.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
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

            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(connection));

            // AutoMapper
            services.AddAutoMapper(cfg => { }, typeof(DanceClassProfile).Assembly);

            // Repositories
            services.AddScoped<DanceClassRepository>();
            services.AddScoped<StudentRepository>();
            services.AddScoped<TeacherRepository>();
            services.AddScoped<EnrollmentRepository>();

            // Validators
            services.AddScoped<DanceClassValidator>();
            services.AddScoped<StudentValidator>();
            services.AddScoped<TeacherValidator>();
            services.AddScoped<EnrollmentValidator>();

            // Services
            services.AddScoped<DanceClassService>();
            services.AddScoped<StudentService>();
            services.AddScoped<TeacherService>();
            services.AddScoped<EnrollmentService>();

            // Controllers
            services.AddScoped<DanceClassController>();
            services.AddScoped<StudentController>();
            services.AddScoped<TeacherController>();
            services.AddScoped<EnrollmentController>();

            // Forms
            services.AddTransient<FormMain>();
            services.AddTransient<FormClass>();
            services.AddTransient<FormStudentList>();
            services.AddTransient<FormTeacherList>();
            services.AddTransient<FormEnrollmentList>();
            services.AddTransient<FormAddEditStudent>();
            services.AddTransient<FormAddEditEnrollment>();

            var provider = services.BuildServiceProvider();

            // Cria banco, caso não exista
            using (var scope = provider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                ctx.Database.EnsureCreated();
            }

            // Start WinForms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(provider.GetRequiredService<FormMain>());
        }
    }
}
