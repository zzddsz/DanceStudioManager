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
        }

        private async void FormStudentList_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            await RefreshGrid();
        }

        private void ApplyStyle()
        {
            if (btnAdd != null) EstilizarBotao(btnAdd);
            if (btnEdit != null) EstilizarBotao(btnEdit);
            if (btnDelete != null) EstilizarBotao(btnDelete);
            if (btnRefresh != null) EstilizarBotao(btnRefresh);

            if (dgv != null)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.BackgroundColor = Color.White;
            }
        }

        private void EstilizarBotao(Button btn)
        {
            btn.BackColor = Color.RosyBrown;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btn.ForeColor = Color.White;
        }

        private async Task RefreshGrid()
        {
            try
            {
                if (dgv != null)
                {
                    var list = await _service.Get<DanceStudioManager.ViewModel.StudentViewModel>();

                    dgv.DataSource = null;
                    dgv.DataSource = list.ToList();

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
                var f = new FormAddEditStudent(_service);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    _ = RefreshGrid();
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
                MessageBox.Show("Selecione um aluno para editar.");
                return;
            }

            try
            {
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;

                var viewModel = await _service.GetById<DanceStudioManager.ViewModel.StudentViewModel>(id);

                if (viewModel == null)
                {
                    MessageBox.Show("Aluno não encontrado.");
                    return;
                }

                var f = new FormAddEditStudent(_service);
                f.LoadStudent(viewModel);

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
    }
}