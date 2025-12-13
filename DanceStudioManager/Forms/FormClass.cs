using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel; // Namespace onde está DanceClassViewModel
using System;
using System.Drawing;
using System.Linq; // NECESSÁRIO para o .ToList()
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormClass : Form
    {
        private readonly DanceClassService _service;

        public FormClass(DanceClassService service)
        {
            _service = service;
            InitializeComponent();
            ApplyStyle();
        }

        private async void FormClass_Load(object sender, EventArgs e)
        {
            await RefreshGrid();
        }

        private async Task RefreshGrid()
        {
            try
            {
                if (dgv != null)
                {
                    // MÉTODO GENÉRICO: Get<T>()
                    var list = await _service.Get<DanceClassViewModel>();

                    dgv.DataSource = null;
                    dgv.DataSource = list.ToList(); // Converter para Lista ajuda o Grid

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
            if (dgv == null) return;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.White;

            if (dgv.Columns.Count > 0)
            {
                if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;

                if (dgv.Columns["Name"] != null) dgv.Columns["Name"].HeaderText = "Name";
                if (dgv.Columns["Teacher"] != null) dgv.Columns["Teacher"].HeaderText = "Teacher";
                if (dgv.Columns["DayOfWeek"] != null) dgv.Columns["DayOfWeek"].HeaderText = "DayOfWeek";
                if (dgv.Columns["Time"] != null) dgv.Columns["Time"].HeaderText = "Time";
                if (dgv.Columns["MaxStudents"] != null) dgv.Columns["MaxStudents"].HeaderText = "Vacancies";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Instancia o formulário de cadastro (que está no mesmo namespace .Forms)
                var f = new FormAddEditClass(_service);

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

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma aula para editar.");
                return;
            }

            try
            {
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;

                // MÉTODO GENÉRICO: GetById<T>(id)
                var viewModel = await _service.GetById<DanceClassViewModel>(id);

                if (viewModel != null)
                {
                    var f = new FormAddEditClass(_service);
                    f.LoadClass(viewModel);

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        await RefreshGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex.Message);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Excluir aula?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;

                    // MÉTODO GENÉRICO: Delete(id)
                    // Ele é void Task e lança exceção se falhar
                    await _service.Delete(id);

                    await RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshGrid();
        }

        private void ApplyStyle()
        {
            this.BackColor = Color.FromArgb(255, 245, 250);

            Button[] botoes = { btnAdd, btnEdit, btnDelete, btnRefresh };
            foreach (var btn in botoes)
            {
                if (btn != null)
                {
                    btn.BackColor = Color.RosyBrown;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }
        }
    }
}