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

           
            panelSidebar.BackColor = Color.FromArgb(115, 55, 55);

            ApplyMenuButton(btnTeachers);
            ApplyMenuButton(btnStudents);
            ApplyMenuButton(btnClasses);
            ApplyMenuButton(btnEnrollments);
        }

       
        private void ApplyMenuButton(Button b)
        {
            b.Height = 55;
            b.Dock = DockStyle.Top;

            b.Margin = new Padding(0, 0, 0, 0);

            b.FlatStyle = FlatStyle.Flat;

            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = Color.White;

           
            b.BackColor = Color.FromArgb(178, 122, 122);

            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(198, 142, 142); 
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(158, 102, 102); 

            b.UseVisualStyleBackColor = false;
        }

  
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