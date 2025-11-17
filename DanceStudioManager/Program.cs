using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DanceStudioManager.Data;
using DanceStudioManager.Mappings;
using DanceStudioManager.Repositories;
using DanceStudioManager.Services;
using DanceStudioManager.Validators;
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

            // A linha de conexão MySQL
            var connection = "server=localhost;database=studio;user=root;password=";

            // DbContext (provider oficial MySQL)
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(connection)
            );

            // AutoMapper - registra os profiles do assembly
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repositório / Service / Validator / Controller
            services.AddScoped<DanceClassRepository>();
            services.AddScoped<DanceClassService>();
            services.AddScoped<DanceClassValidator>();
            services.AddScoped<DanceClassController>();

            // Forms: Devem ser Transient para garantir que uma nova janela seja criada
            // a cada vez que for solicitada (especialmente FormAddEdit).
            services.AddTransient<Form1>();
            services.AddTransient<FormAddEdit>();

            var provider = services.BuildServiceProvider();

            // Garantir que o banco/tabela exista: (cria DB/tabelas se não existirem)
            using (var scope = provider.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                // Atenção: Esta linha Assume que você configurou as Entidades no AppDbContext
                ctx.Database.EnsureCreated();
            }

            // Configuração padrão do Windows Forms
            ApplicationConfiguration.Initialize();

            // Inicia a aplicação com o Form1 injetado
            Application.Run(provider.GetRequiredService<Form1>());
        }
    }
}