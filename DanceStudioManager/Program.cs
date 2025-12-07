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

            var connection = "server=localhost;port=3306;database=studio;user=root;password=";

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(connection));

            services.AddAutoMapper(cfg => { }, typeof(DanceClassProfile).Assembly);

            services.AddScoped<DanceClassRepository>();
            services.AddScoped<StudentRepository>();
            services.AddScoped<TeacherRepository>();
            services.AddScoped<EnrollmentRepository>();

            services.AddScoped<DanceClassValidator>();
            services.AddScoped<StudentValidator>();
            services.AddScoped<TeacherValidator>();
            services.AddScoped<EnrollmentValidator>();

            services.AddScoped<DanceClassService>();
            services.AddScoped<StudentService>();
            services.AddScoped<TeacherService>();
            services.AddScoped<EnrollmentService>();

            services.AddScoped<DanceClassController>();
            services.AddScoped<StudentController>();
            services.AddScoped<TeacherController>();
            services.AddScoped<EnrollmentController>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormClass>();
            services.AddTransient<FormStudentList>();
            services.AddTransient<FormTeacherList>();
            services.AddTransient<FormEnrollmentList>();
            services.AddTransient<FormAddEditStudent>();
            services.AddTransient<FormAddEditEnrollment>();
            services.AddTransient<FormAddEditClass>();

            var provider = services.BuildServiceProvider();

            try
            {
                using (var scope = provider.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    ctx.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível conectar ao Banco de Dados.\n\nVerifique se o XAMPP ou MySQL está rodando!\n\nErro técnico: {ex.Message}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(provider.GetRequiredService<FormMain>());
        }
    }
}