using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormTeacherList : Form
    {
        private readonly TeacherService _service;

        public FormTeacherList(TeacherService service)
        {
            _service = service;
            InitializeComponent();
        }

        private async void FormTeacherList_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            await RefreshGrid();
        }

        private async Task RefreshGrid()
        {
            try
            {
                if (dgv != null)
                {
                    var list = await _service.Get<TeacherViewModel>();

                    dgv.DataSource = null;
                    dgv.DataSource = list.ToList();

                    if (dgv.Columns["Id"] != null)
                        dgv.Columns["Id"].Visible = false;

                    if (dgv.Columns["Speciality"] != null)
                        dgv.Columns["Speciality"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista: " + ex.Message);
            }
        }

        // ================= ADD =================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new FormAddEditTeacher(_service);
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

        // ================= EDIT =================
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um professor para editar.");
                return;
            }

            try
            {
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;

                var dto = await _service.GetById<TeacherViewModel>(id);

                if (dto != null)
                {
                    var f = new FormAddEditTeacher(_service);
                    f.LoadForEdit(dto);

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

        // ================= DELETE =================
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                return;

            if (MessageBox.Show("Excluir?", "Confirmação",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        // ================= REFRESH =================
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
            }

            Button[] botoes = { btnAdd, btnEdit, btnDelete, btnRefresh };
            foreach (var btn in botoes)
            {
                if (btn != null)
                {
                    btn.BackColor = Color.RosyBrown;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                }
            }
        }
    }
}
