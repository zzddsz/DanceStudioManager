using DanceStudioManager.Controllers;
using DanceStudio.Service.DTOs;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DanceStudioManager.Forms;
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
            try
            {
                var list = await _controller.Listar();
                dgv.DataSource = list;

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            var f = new FormAddEditClass(_controller);

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

            if (dgv.SelectedRows[0].Cells["Id"].Value == null) return;

            int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;

            try
            {
                DanceClassDTO dto = await _controller.Buscar(id);

                if (dto == null)
                {
                    MessageBox.Show("Aula não encontrada no banco de dados.");
                    return;
                }

                var f = new FormAddEditClass(_controller);

                f.LoadClass(dto);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados para edição: " + ex.Message);
            }
        }

        private async void BtnDelete_Click(object sender, System.EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma aula para excluir.");
                return;
            }

            if (MessageBox.Show("Tem certeza que deseja excluir esta aula?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                    var resultado = await _controller.Remover(id);

                    MessageBox.Show(resultado.msg);

                    if (resultado.ok)
                    {
                        await RefreshGrid();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        private async void BtnRefresh_Click(object sender, System.EventArgs e)
        {
            await RefreshGrid();
        }
    }
}