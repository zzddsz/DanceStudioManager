using DanceStudioManager.Controllers;
using DanceStudio.Service.DTOs;
using DanceStudioManager;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormTeacherList : Form
    {
        private readonly TeacherController _controller;
        private DataGridView _gridEncontrado;

        public FormTeacherList(TeacherController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private async void FormTeacherList_Load(object sender, EventArgs e)
        {
            _gridEncontrado = LocalizarGrid(this);

            if (_gridEncontrado == null)
            {
                MessageBox.Show("Aviso: Grid não encontrado na tela.");
                return;
            }

            // Conecta os botões
            ConfigurarBotao(btnAdd, btnAdd_Click);
            ConfigurarBotao(btnEdit, btnEdit_Click);
            ConfigurarBotao(btnDelete, btnDelete_Click);
            ConfigurarBotao(btnRefresh, btnRefresh_Click);

            ApplyStyle();
            await RefreshGrid();
        }

        private DataGridView LocalizarGrid(Control pai)
        {
            foreach (Control c in pai.Controls)
            {
                if (c is DataGridView dgv) return dgv;
                if (c.HasChildren)
                {
                    var encontrado = LocalizarGrid(c);
                    if (encontrado != null) return encontrado;
                }
            }
            return null;
        }

        private void ConfigurarBotao(Button btn, EventHandler evento)
        {
            if (btn != null)
            {
                btn.Click -= evento;
                btn.Click += evento;
            }
        }

        private void ApplyStyle()
        {
            Button[] botoes = { btnAdd, btnEdit, btnDelete, btnRefresh };
            foreach (var btn in botoes)
            {
                if (btn != null)
                {
                    btn.BackColor = Color.RosyBrown;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                    btn.ForeColor = Color.White;
                }
            }

            if (_gridEncontrado != null)
            {
                _gridEncontrado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                _gridEncontrado.BackgroundColor = Color.White;
                _gridEncontrado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                _gridEncontrado.RowHeadersVisible = false;
            }
        }

        private async Task RefreshGrid()
        {
            try
            {
                if (_gridEncontrado != null)
                {
                    var list = await _controller.Listar();
                    _gridEncontrado.DataSource = null;
                    _gridEncontrado.DataSource = list;

                    if (_gridEncontrado.Columns["Id"] != null)
                        _gridEncontrado.Columns["Id"].Visible = false;

                    if (_gridEncontrado.Columns["Name"] != null)
                        _gridEncontrado.Columns["Name"].HeaderText = "Name";

                    if (_gridEncontrado.Columns["Speciality"] != null)
                        _gridEncontrado.Columns["Speciality"].HeaderText = "Specialty";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar: " + ex.Message);
            }
        }

        // --- AQUI ESTAVA O ERRO DE NAMESPACE ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Removemos o "DanceStudioManager.Forms." da frente.
                // Graças ao 'using DanceStudioManager;' lá em cima, ele acha o Form onde ele estiver.
                var f = new FormAddEditTeacher(_controller);

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
            if (_gridEncontrado == null || _gridEncontrado.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione para editar.");
                return;
            }

            try
            {
                int id = (int)_gridEncontrado.SelectedRows[0].Cells["Id"].Value;
                var dto = await _controller.Buscar(id);

                if (dto != null)
                {
                    var f = new FormAddEditTeacher(_controller);
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_gridEncontrado == null || _gridEncontrado.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Excluir?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = (int)_gridEncontrado.SelectedRows[0].Cells["Id"].Value;
                    await _controller.Remover(id);
                    await RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshGrid();
        }
    }
}