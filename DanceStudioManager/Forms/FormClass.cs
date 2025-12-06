using DanceStudioManager.Controllers;
using DanceStudio.Service.DTOs;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ReaLTaiizor.Forms;

namespace DanceStudioManager
{
    public partial class FormClass : Form
    {
        private readonly DanceClassController _controller;

        public FormClass(DanceClassController controller)
        {
            _controller = controller;
            InitializeComponent();

            this.BackColor = Color.FromArgb(255, 245, 250);
        }

        private async void Form1_Load(object sender, System.EventArgs e)
        {
            await RefreshGrid();
        }

        private async Task RefreshGrid()
        {
            var list = await _controller.Listar();
            dgv.DataSource = list;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var f = new FormAddEditStudent(_controller);

            if (f.ShowDialog() == DialogResult.OK)
            {
                _ = RefreshGrid();
            }
        }

        private async void BtnEdit_Click(object sender, System.EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma aula para editar.");
                return;
            }

            int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;

            DanceClassDTO dto = await _controller.Buscar(id);

            if (dto == null)
            {
                MessageBox.Show("Aula não encontrada.");
                return;
            }

            var f = new FormAddEditStudent(_controller);
            f.LoadForEdit(dto);

            if (f.ShowDialog() == DialogResult.OK)
            {
                await RefreshGrid();
            }
        }

        private async void BtnDelete_Click(object sender, System.EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma aula para excluir.");
                return;
            }

            if (MessageBox.Show("Tem certeza?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;

                var resultado = await _controller.Remover(id);

                MessageBox.Show(resultado.msg);

                if (resultado.ok)
                {
                    await RefreshGrid();
                }
            }
        }

        private async void BtnRefresh_Click(object sender, System.EventArgs e)
        {
            await RefreshGrid();
        }
    }
}
