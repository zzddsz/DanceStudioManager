using DanceStudioManager.Controllers;
using DanceStudio.Service.DTOs;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormStudentList : Form
    {
        private readonly StudentController _controller;

        public FormStudentList(StudentController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private async void FormStudentList_Load(object sender, EventArgs e)
        {
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;

            ApplyStyle();
            await RefreshGrid();
        }

        private void ApplyStyle()
        {
            Button[] b = { btnAdd, btnEdit, btnDelete, btnRefresh };
            foreach (var btn in b)
            {
                btn.BackColor = Color.RosyBrown;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                btn.ForeColor = Color.White;
            }

            if (dgv != null)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.BackgroundColor = Color.White;
            }
        }

        private async Task RefreshGrid()
        {
            try
            {
                if (dgv != null)
                {
                    var list = await _controller.Listar();
                    dgv.DataSource = list;

                    if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new DanceStudioManager.FormAddEditStudent(_controller);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    _ = RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    var f = new DanceStudioManager.FormAddEditStudent(_controller);
                    if (f.ShowDialog() == DialogResult.OK) _ = RefreshGrid();
                }
                catch
                {
                    MessageBox.Show("Erro ao abrir formulário: " + ex.Message);
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um aluno para editar.");
                return;
            }

            try
            {
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                var dto = await _controller.Buscar(id);

                if (dto == null)
                {
                    MessageBox.Show("Aluno não encontrado.");
                    return;
                }

                var f = new DanceStudioManager.FormAddEditStudent(_controller);
                f.LoadStudent(dto);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
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

            if (MessageBox.Show("Excluir este aluno?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                    await _controller.Remover(id);
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
    }
}