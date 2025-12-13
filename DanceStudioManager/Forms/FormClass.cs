using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormClass : Form
    {
        private readonly DanceClassService _service;
        private readonly TeacherService _teacherService;

        public FormClass(DanceClassService service, TeacherService teacherService)
        {
            _service = service;
            _teacherService = teacherService;
            InitializeComponent();
            ApplyStyle();

            // Proteção de Eventos
            if (btnAdd != null) { btnAdd.Click -= BtnAdd_Click; btnAdd.Click += BtnAdd_Click; }
            if (btnEdit != null) { btnEdit.Click -= BtnEdit_Click; btnEdit.Click += BtnEdit_Click; }
            if (btnDelete != null) { btnDelete.Click -= BtnDelete_Click; btnDelete.Click += BtnDelete_Click; }
            if (btnRefresh != null) { btnRefresh.Click -= BtnRefresh_Click; btnRefresh.Click += BtnRefresh_Click; }

            this.Load -= FormClass_Load;
            this.Load += FormClass_Load;
        }

        private async void FormClass_Load(object sender, EventArgs e)
        {
            await RefreshGrid();
        }

        private async Task RefreshGrid()
        {
            try
            {
                // Inclui "Teacher" para exibir o nome do professor no Grid
                var includes = new System.Collections.Generic.List<string> { "Teacher" };
                var list = await _service.Get<DanceClassViewModel>(includes);

                if (dgv != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = list.ToList();

                    if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
                    if (dgv.Columns["TeacherId"] != null) dgv.Columns["TeacherId"].Visible = false;

                    if (dgv.Columns["Name"] != null) dgv.Columns["Name"].HeaderText = "Class Name";
                    if (dgv.Columns["TeacherName"] != null) dgv.Columns["TeacherName"].HeaderText = "Teacher";
                    if (dgv.Columns["DayOfWeek"] != null) dgv.Columns["DayOfWeek"].HeaderText = "Day";

                    if (dgv.Columns["Time"] != null)
                    {
                        dgv.Columns["Time"].HeaderText = "Time";
                        // --- ALTERAÇÃO AQUI ---
                        // Formata para Hora:Minuto (ex: 13:30) removendo os segundos e milissegundos
                        dgv.Columns["Time"].DefaultCellStyle.Format = @"hh\:mm";
                    }

                    if (dgv.Columns["MaxStudents"] != null) dgv.Columns["MaxStudents"].HeaderText = "Max Students";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading classes: " + ex.Message);
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new FormAddEditClass(_service, _teacherService);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening form: " + ex.Message);
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a class to edit.");
                return;
            }

            try
            {
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                var includes = new System.Collections.Generic.List<string> { "Teacher" };
                var viewModel = await _service.GetById<DanceClassViewModel>(id, includes);

                if (viewModel != null)
                {
                    var f = new FormAddEditClass(_service, _teacherService);
                    f.LoadClass(viewModel);

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        await RefreshGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error editing: " + ex.Message);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Delete class?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                    await _service.Delete(id);
                    await RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message);
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshGrid();
        }

        private void ApplyStyle()
        {
            if (dgv != null)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.BackgroundColor = Color.White;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;
                dgv.BorderStyle = BorderStyle.None;
            }

            Button[] botoes = { btnAdd, btnEdit, btnDelete, btnRefresh };
            foreach (var btn in botoes)
            {
                if (btn != null)
                {
                    btn.BackColor = Color.RosyBrown;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }
    }
}