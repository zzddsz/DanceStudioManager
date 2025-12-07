using DanceStudioManager.Controllers;
using DanceStudio.Service.DTOs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanceStudioManager // Namespace deve ser igual ao do Designer (sem .Forms)
{
    public partial class FormAddEditStudent : Form
    {
        private readonly StudentController _controller;
        private StudentDTO _editing;

        public FormAddEditStudent(StudentController controller)
        {
            _controller = controller;
            InitializeComponent();
            ApplyTheme();

            // Garante que os eventos de clique funcionem
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public void LoadStudent(StudentDTO dto)
        {
            _editing = dto;
            txtName.Text = dto.Name;
            txtAge.Text = dto.Age.ToString();
            txtLevel.Text = dto.Level;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("O nome é obrigatório.");
                return;
            }

            // Desabilita botão
            if (sender is Button btnSender) btnSender.Enabled = false;

            try
            {
                // Converte a idade
                int.TryParse(txtAge.Text, out int idade);

                var dto = new StudentDTO
                {
                    Id = _editing != null ? _editing.Id : 0,
                    Name = txtName.Text,
                    Age = idade,           // Passa a idade capturada
                    Level = txtLevel.Text  // Passa o nível capturado
                };

                if (_editing == null)
                    await _controller.Add(dto);
                else
                    await _controller.Atualizar(dto.Id, dto);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
                if (sender is Button btnError) btnError.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(255, 235, 245);
            if (panelMain != null) panelMain.BackColor = Color.White;
            StyleButton(btnSave);
            StyleButton(btnCancel);
        }

        private static void StyleButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = Color.FromArgb(255, 170, 200);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 0;
        }
    }
}