using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormStudentList : Form
    {
        private readonly StudentService _service;

        public FormStudentList(StudentService service)
        {
            _service = service;
            InitializeComponent();
            ApplyStyle();

            // =======================================================
            // PROTEÇÃO DE EVENTOS (Evita cliques duplos ou nulos)
            // =======================================================
            if (btnAdd != null) { btnAdd.Click -= btnAdd_Click; btnAdd.Click += btnAdd_Click; }
            if (btnEdit != null) { btnEdit.Click -= btnEdit_Click; btnEdit.Click += btnEdit_Click; }
            if (btnDelete != null) { btnDelete.Click -= btnDelete_Click; btnDelete.Click += btnDelete_Click; }
            if (btnRefresh != null) { btnRefresh.Click -= btnRefresh_Click; btnRefresh.Click += btnRefresh_Click; }

            this.Load -= FormStudentList_Load;
            this.Load += FormStudentList_Load;
        }

        private async void FormStudentList_Load(object sender, EventArgs e)
        {
            await RefreshGrid();
        }

        private async Task RefreshGrid()
        {
            try
            {
                var list = await _service.Get<StudentViewModel>();

                if (dgv != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = list.ToList();

                    // Oculta apenas o ID
                    if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;

                    // Ajuste de colunas
                    if (dgv.Columns["Name"] != null) dgv.Columns["Name"].HeaderText = "Name";
                    if (dgv.Columns["Age"] != null) dgv.Columns["Age"].HeaderText = "Age";
                    if (dgv.Columns["Level"] != null) dgv.Columns["Level"].HeaderText = "Level";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista: " + ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new FormAddEditStudent(_service);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir formulário: " + ex.Message);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a student to edit.");
                return;
            }

            try
            {
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                var viewModel = await _service.GetById<StudentViewModel>(id);

                if (viewModel != null)
                {
                    var f = new FormAddEditStudent(_service);
                    f.LoadStudent(viewModel);

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        await RefreshGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Delete student?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                    await _service.Delete(id);
                    await RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
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
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }
    }
}