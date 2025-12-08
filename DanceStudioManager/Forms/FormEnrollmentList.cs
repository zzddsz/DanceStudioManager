using DanceStudio.Service.DTOs;
using DanceStudioManager.Controllers;
using DanceStudioManager.Views;
using ReaLTaiizor.Forms;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager
{
    public partial class FormEnrollmentList : Form
    {
        private readonly EnrollmentController _controller;

        private readonly StudentController _studentController;
        private readonly DanceClassController _classController;

        private readonly Color corPainel = Color.FromArgb(115, 55, 55);
        private readonly Color corBotao = Color.FromArgb(178, 122, 122);

        public FormEnrollmentList(
            EnrollmentController controller,
            StudentController studentController,
            DanceClassController classController)
        {
            _controller = controller;
            _studentController = studentController;
            _classController = classController;     

            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(255, 245, 245);
            this.Font = new Font("Segoe UI", 10);
            panelTop.BackColor = corPainel;
            StyleButton(btnAdd);
            StyleButton(btnDelete);
        }

        private void StyleButton(Button btn)
        {
            btn.BackColor = corBotao;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(198, 142, 142);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(158, 102, 102);
            btn.UseVisualStyleBackColor = false;
        }

        private async void FormEnrollmentList_Load(object sender, EventArgs e)
        {
            await CarregarLista();
        }

        private async Task CarregarLista()
        {
            var lista = await _controller.Listar();
            dgvEnrollments.DataSource = lista;

            dgvEnrollments.BackgroundColor = Color.White;
            dgvEnrollments.BorderStyle = BorderStyle.None;

            if (dgvEnrollments.Columns.Count > 0)
            {
                if (dgvEnrollments.Columns.Contains("Id")) dgvEnrollments.Columns["Id"].Visible = false;
                if (dgvEnrollments.Columns.Contains("StudentId")) dgvEnrollments.Columns["StudentId"].Visible = false;
                if (dgvEnrollments.Columns.Contains("DanceClassId")) dgvEnrollments.Columns["DanceClassId"].Visible = false;

                if (dgvEnrollments.Columns.Contains("StudentName")) dgvEnrollments.Columns["StudentName"].HeaderText = "Student";
                if (dgvEnrollments.Columns.Contains("DanceClassName")) dgvEnrollments.Columns["DanceClassName"].HeaderText = "Class";
                if (dgvEnrollments.Columns.Contains("Date")) dgvEnrollments.Columns["Date"].HeaderText = "Date";

                dgvEnrollments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormAddEditEnrollment(_controller, _studentController, _classController);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await CarregarLista();
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEnrollments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma matrícula para remover.");
                return;
            }

            var cellValue = dgvEnrollments.SelectedRows[0].Cells["Id"].Value;
            if (cellValue == null) return;

            int id = (int)cellValue;

            var confirm = MessageBox.Show(
                "Deseja remover esta matrícula?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                var result = await _controller.Remover(id);
                MessageBox.Show(result.msg);

                if (result.ok)
                    await CarregarLista();
            }
        }
    }
}