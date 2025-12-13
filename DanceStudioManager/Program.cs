using AutoMapper;
using DanceStudio.Domain.Entities;
using DanceStudio.Repository.Context;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.Base;
using DanceStudio.Service.Services;
using DanceStudio.Service.Validators;
using DanceStudioManager.Forms;
using DanceStudioManager.ViewModel;
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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            services.AddLogging();

            // 1. BANCO DE DADOS
            var connectionString = "server=localhost;port=3306;database=studio;user=root;password=";
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(connectionString), ServiceLifetime.Transient);

            // 2. AUTOMAPPER (A CORREÇÃO ESTÁ AQUI)
            services.AddAutoMapper(cfg =>
            {
                // Student e Teacher
                cfg.CreateMap<Student, StudentViewModel>().ReverseMap();
                cfg.CreateMap<Teacher, TeacherViewModel>().ReverseMap();

                // --- DANCE CLASS (AULA) ---
                // Ida (Banco -> Tela): Transforma Objeto Teacher em String Nome
                cfg.CreateMap<DanceClass, DanceClassViewModel>()
                   .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.Name));

                // Volta (Tela -> Banco): Transforma o ID selecionado no FK do Banco
                cfg.CreateMap<DanceClassViewModel, DanceClass>()
                   .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                   .ForMember(dest => dest.Teacher, opt => opt.Ignore()); // Ignora o objeto, usa só o ID

                // --- ENROLLMENT (MATRÍCULA) ---
                cfg.CreateMap<Enrollment, EnrollmentViewModel>()
                    .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
                    .ForMember(dest => dest.DanceClassName, opt => opt.MapFrom(src => src.DanceClass.Name));

                cfg.CreateMap<EnrollmentViewModel, Enrollment>()
                    .ForMember(dest => dest.Student, opt => opt.Ignore())
                    .ForMember(dest => dest.DanceClass, opt => opt.Ignore());
            });

            // 3. INJEÇÃO DE DEPENDÊNCIA
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<DanceClassRepository>();
            services.AddTransient<StudentRepository>();
            services.AddTransient<TeacherRepository>();
            services.AddTransient<EnrollmentRepository>();

            services.AddTransient<DanceClassValidator>();
            services.AddTransient<StudentValidator>();
            services.AddTransient<TeacherValidator>();
            services.AddTransient<EnrollmentValidator>();

            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<DanceClassService>();
            services.AddTransient<StudentService>();
            services.AddTransient<TeacherService>();
            services.AddTransient<EnrollmentService>();

            // Forms
            services.AddTransient<FormMain>();
            services.AddTransient<FormClass>();
            services.AddTransient<FormStudentList>();
            services.AddTransient<FormTeacherList>();
            services.AddTransient<FormEnrollmentList>();
            services.AddTransient<FormAddEditStudent>();
            services.AddTransient<FormAddEditEnrollment>();
            services.AddTransient<FormAddEditClass>();
            services.AddTransient<FormAddEditTeacher>();

            var provider = services.BuildServiceProvider();

            // 4. INICIALIZAÇÃO
            try
            {
                using (var scope = provider.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    ctx.Database.Migrate();
                }
                var mainForm = provider.GetRequiredService<FormMain>();
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro fatal: {ex.Message}");
            }
        }
    }
}