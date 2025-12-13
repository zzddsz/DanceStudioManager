using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using DanceStudioManager.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager
{
    public partial class FormEnrollmentList : Form
    {
        private readonly EnrollmentService _service;
        private readonly StudentService _studentService;
        private readonly DanceClassService _classService;

        public FormEnrollmentList(
            EnrollmentService service,
            StudentService studentService,
            DanceClassService classService)
        {
            _service = service;
            _studentService = studentService;
            _classService = classService;

            InitializeComponent();
            ApplyTheme();

            // Proteção de Eventos
            if (btnAdd != null) { btnAdd.Click -= BtnAdd_Click; btnAdd.Click += BtnAdd_Click; }
            if (btnDelete != null) { btnDelete.Click -= BtnDelete_Click; btnDelete.Click += BtnDelete_Click; }

            this.Load -= FormEnrollmentList_Load;
            this.Load += FormEnrollmentList_Load;
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(255, 245, 245);
            this.Font = new Font("Segoe UI", 10);
            if (panelTop != null) panelTop.BackColor = Color.FromArgb(115, 55, 55);
            StyleButton(btnAdd);
            StyleButton(btnDelete);
        }

        private void StyleButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = Color.FromArgb(178, 122, 122);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.Cursor = Cursors.Hand;
        }

        private async void FormEnrollmentList_Load(object sender, EventArgs e)
        {
            await CarregarLista();
        }

        private async Task CarregarLista()
        {
            try
            {
                var includes = new List<string> { "Student", "DanceClass" };
                var lista = await _service.Get<EnrollmentViewModel>(includes);

                if (dgvEnrollments != null)
                {
                    dgvEnrollments.DataSource = null;
                    dgvEnrollments.DataSource = lista.ToList();
                    ConfigurarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista: " + ex.Message);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvEnrollments == null) return;

            dgvEnrollments.BackgroundColor = Color.White;
            dgvEnrollments.BorderStyle = BorderStyle.None;
            dgvEnrollments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnrollments.RowHeadersVisible = false;
            dgvEnrollments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvEnrollments.Columns.Count > 0)
            {
                if (dgvEnrollments.Columns["Id"] != null) dgvEnrollments.Columns["Id"].Visible = false;
                if (dgvEnrollments.Columns["StudentId"] != null) dgvEnrollments.Columns["StudentId"].Visible = false;
                if (dgvEnrollments.Columns["DanceClassId"] != null) dgvEnrollments.Columns["DanceClassId"].Visible = false;

                if (dgvEnrollments.Columns["StudentName"] != null) dgvEnrollments.Columns["StudentName"].HeaderText = "Student";
                if (dgvEnrollments.Columns["DanceClassName"] != null) dgvEnrollments.Columns["DanceClassName"].HeaderText = "Class";
                if (dgvEnrollments.Columns["Date"] != null) dgvEnrollments.Columns["Date"].HeaderText = "Date";
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormAddEditEnrollment(_service, _studentService, _classService);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await CarregarLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir formulário: " + ex.Message);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEnrollments.SelectedRows.Count == 0) return;

            var cellValue = dgvEnrollments.SelectedRows[0].Cells["Id"].Value;
            if (cellValue == null) return;
            int id = (int)cellValue;

            if (MessageBox.Show("Remove enrollment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _service.Delete(id);
                    MessageBox.Show("Removed successfully!");
                    await CarregarLista();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing: " + ex.Message);
                }
            }
        }
    }
}