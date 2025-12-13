using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using DanceStudio.Service.Validators;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormAddEditStudent : Form
    {
        private readonly StudentService _service;
        private StudentViewModel _editing;

        public FormAddEditStudent(StudentService service)
        {
            _service = service;
            InitializeComponent();
            ApplyTheme();

            if (btnSave != null) btnSave.Click += BtnSave_Click;
            if (btnCancel != null) btnCancel.Click += BtnCancel_Click;
        }

        public void LoadStudent(StudentViewModel viewModel)
        {
            _editing = viewModel;
            txtName.Text = viewModel.Name;
            txtAge.Text = viewModel.Age.ToString();
            txtLevel.Text = viewModel.Level;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("O nome é obrigatório.");
                return;
            }

            if (sender is Button btnSender) btnSender.Enabled = false;

            try
            {
                int.TryParse(txtAge.Text, out int idade);

                var viewModel = new StudentViewModel
                {
                    Id = _editing != null ? _editing.Id : 0,
                    Name = txtName.Text,
                    Age = idade,
                    Level = txtLevel.Text
                };

                if (_editing == null)
                {
                    // Add<Input, Output, Validator>
                    await _service.Add<StudentViewModel, StudentViewModel, StudentValidator>(viewModel);
                }
                else
                {
                    // Update<Input, Output, Validator>
                    await _service.Update<StudentViewModel, StudentViewModel, StudentValidator>(viewModel);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
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
            if (Controls.ContainsKey("panelMain")) Controls["panelMain"].BackColor = Color.White;
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