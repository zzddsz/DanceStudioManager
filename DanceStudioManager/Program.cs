using DanceStudio.Repository.Context;
using DanceStudio.Repository.Repositories;
using DanceStudio.Service.Base;
using DanceStudio.Service.Services;
using DanceStudio.Service.Validators;
using DanceStudioManager.Forms;
using DanceStudioManager.Views;
using DanceStudioManager.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;
using DanceStudio.Domain.Entities;

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

            // ================================
            // ? LOGGING (mínimo – SEM PACOTES)
            // ================================
            services.AddLogging();

            // ================================
            // 1. Banco de Dados
            // ================================
            var connectionString = "server=localhost;port=3306;database=studio;user=root;password=";
            services.AddDbContext<AppDbContext>(
                options => options.UseMySQL(connectionString),
                ServiceLifetime.Transient
            );

            // ================================
            // 2. AutoMapper
            // ================================
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Student, StudentViewModel>().ReverseMap();
                cfg.CreateMap<Teacher, TeacherViewModel>().ReverseMap();
                cfg.CreateMap<DanceClass, DanceClassViewModel>().ReverseMap();

                cfg.CreateMap<Enrollment, EnrollmentViewModel>()
                    .ForMember(dest => dest.StudentName,
                        opt => opt.MapFrom(src => src.Student.Name))
                    .ForMember(dest => dest.DanceClassName,
                        opt => opt.MapFrom(src => src.DanceClass.Name));

                cfg.CreateMap<EnrollmentViewModel, Enrollment>()
                    .ForMember(dest => dest.Student, opt => opt.Ignore())
                    .ForMember(dest => dest.DanceClass, opt => opt.Ignore());
            });

            // ================================
            // 3. Injeção de Dependências
            // ================================
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

            // ================================
            // 4. Forms
            // ================================
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

            // ================================
            // 5. Inicializa o Banco
            // ================================
            try
            {
                using (var scope = provider.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    ctx.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar banco: {ex.Message}");
            }

            // ================================
            // 6. Inicia a aplicação
            // ================================
            try
            {
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
