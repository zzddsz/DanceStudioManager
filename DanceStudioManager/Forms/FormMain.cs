using DanceStudioManager.Forms;
using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanceStudioManager
{
    public partial class FormMain : MaterialForm
    {
        private readonly IServiceProvider _provider;

        public FormMain(IServiceProvider provider)
        {
            _provider = provider;
            InitializeComponent();
            CustomizeDesign();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Dance Studio Manager";
        }

        private void CustomizeDesign()
        {
            panelSidebar.BackColor = Color.FromArgb(115, 55, 55);

            ApplyMenuButton(btnTeachers);
            ApplyMenuButton(btnStudents);
            ApplyMenuButton(btnClasses);
            ApplyMenuButton(btnEnrollments);
        }

        private void ApplyMenuButton(Button b)
        {
            if (b == null) return;

            b.Height = 55;
            b.Dock = DockStyle.Top;
            b.Margin = new Padding(0);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = Color.FromArgb(115, 55, 55); 
            b.BackColor = Color.FromArgb(178, 122, 122);
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            b.Cursor = Cursors.Hand;

            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(198, 142, 142);
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(158, 102, 102);
            b.UseVisualStyleBackColor = false;
        }

        private void BtnTeachers_Click(object sender, EventArgs e)
        {
            try
            {
                var form = _provider.GetRequiredService<FormTeacherList>();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir Teachers: " + ex.Message);
            }
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            try
            {
                var form = _provider.GetRequiredService<FormStudentList>();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir Students: " + ex.Message);
            }
        }

        private void BtnClasses_Click(object sender, EventArgs e)
        {
            try
            {
                var form = _provider.GetRequiredService<FormClass>();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir Classes: " + ex.Message);
            }
        }

        private void BtnEnrollments_Click(object sender, EventArgs e)
        {
            try
            {
                var form = _provider.GetRequiredService<FormEnrollmentList>();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir Enrollments: " + ex.Message);
            }
        }
    }
}