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
            ApplyStyle();

            if (btnAdd != null) { btnAdd.Click -= btnAdd_Click; btnAdd.Click += btnAdd_Click; }
            if (btnEdit != null) { btnEdit.Click -= btnEdit_Click; btnEdit.Click += btnEdit_Click; }
            if (btnDelete != null) { btnDelete.Click -= btnDelete_Click; btnDelete.Click += btnDelete_Click; }
            if (btnRefresh != null) { btnRefresh.Click -= btnRefresh_Click; btnRefresh.Click += btnRefresh_Click; }

            this.Load -= FormTeacherList_Load;
            this.Load += FormTeacherList_Load;
        }

        private async void FormTeacherList_Load(object sender, EventArgs e) => await RefreshGrid();
        private async void btnRefresh_Click(object sender, EventArgs e) => await RefreshGrid();

        private async Task RefreshGrid()
        {
            try
            {
                var list = await _service.Get<TeacherViewModel>();
                if (dgv != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = list.ToList();
                    if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
                    if (dgv.Columns["DanceClass"] != null) dgv.Columns["DanceClass"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (new FormAddEditTeacher(_service).ShowDialog() == DialogResult.OK)
                await RefreshGrid();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecione um professor."); return; }

            try
            {
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                var dto = await _service.GetById<TeacherViewModel>(id);
                if (dto != null)
                {
                    var f = new FormAddEditTeacher(_service);
                    f.LoadForEdit(dto);
                    if (f.ShowDialog() == DialogResult.OK) await RefreshGrid();
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Deseja excluir?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                    await _service.Delete(id);
                    await RefreshGrid();
                }
                catch (Exception ex) { MessageBox.Show("Erro ao excluir: " + ex.Message); }
            }
        }

        private void ApplyStyle()
        {
            if (dgv != null)
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.BackgroundColor = Color.White;
                dgv.RowHeadersVisible = false;
            }
        }
    }
}