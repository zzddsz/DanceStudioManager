using DanceStudioManager.Controllers;
using DanceStudioManager.Forms;
using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanceStudioManager
{
    public partial class FormMain : Form
    {
        private readonly DanceClassController _classController;
        private readonly StudentController _studentController;
        private readonly TeacherController _teacherController;
        private readonly EnrollmentController _enrollmentController;
        private readonly IServiceProvider _provider;

        public FormMain(
            DanceClassController classController,
            StudentController studentController,
            TeacherController teacherController,
            EnrollmentController enrollmentController,
            IServiceProvider provider)
        {
            _classController = classController;
            _studentController = studentController;
            _teacherController = teacherController;
            _enrollmentController = enrollmentController;
            _provider = provider;

            InitializeComponent();

            // --- CORREÇÃO DO FUNDO DO SIDEBAR ---
            // Define o fundo vinho escuro para combinar com os botões
            panelSidebar.BackColor = Color.FromArgb(115, 55, 55);

            // --- APLICA O ESTILO AOS BOTÕES ---
            ApplyMenuButton(btnTeachers);
            ApplyMenuButton(btnStudents);
            ApplyMenuButton(btnClasses);
            ApplyMenuButton(btnEnrollments);
        }

        // ============================================
        // MÉTODO DE ESTILO — AQUI ESTAVA O PROBLEMA
        // ============================================
        private void ApplyMenuButton(Button b)
        {
            b.Height = 55;
            b.Dock = DockStyle.Top;

            // Margem entre os botões (para ver a cor de fundo do painel entre eles, se quiser)
            // Se quiser colado igual a imagem 2, pode deixar 0 ou manter pequeno
            b.Margin = new Padding(0, 0, 0, 0);

            b.FlatStyle = FlatStyle.Flat;

            // --- 1. AQUI COLOCAMOS A BORDA BRANCA ---
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = Color.White;

            // --- 2. AQUI TROCAMOS O ROSA CHICLETE PELO ROSA ANTIGO (TERRACOTA) ---
            // Cor antiga (Rosa Feio): 255, 150, 190
            // Cor nova (Igual imagem): 178, 122, 122
            b.BackColor = Color.FromArgb(178, 122, 122);

            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Cores de reação do mouse (Hover e Click) ajustadas para o tom terracota
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(198, 142, 142); // Um pouco mais claro
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(158, 102, 102); // Um pouco mais escuro

            // Garante que a cor pegue
            b.UseVisualStyleBackColor = false;
        }

        // ============================================
        // EVENTOS DE CLICK
        // ============================================
        private void BtnTeachers_Click(object sender, EventArgs e)
        {
            var form = ActivatorUtilities.CreateInstance<FormTeacherList>(_provider);
            form.ShowDialog();
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            var form = ActivatorUtilities.CreateInstance<FormStudentList>(_provider);
            form.ShowDialog();
        }

        private void BtnClasses_Click(object sender, EventArgs e)
        {
            var form = ActivatorUtilities.CreateInstance<FormClass>(_provider);
            form.ShowDialog();
        }

        private void BtnEnrollments_Click(object sender, EventArgs e)
        {
            var form = ActivatorUtilities.CreateInstance<FormEnrollmentList>(_provider);
            form.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Dance Studio Manager";
        }
    }
}