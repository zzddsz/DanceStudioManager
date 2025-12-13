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

            if (btnSave != null) { btnSave.Click -= BtnSave_Click; btnSave.Click += BtnSave_Click; }
            if (btnCancel != null) { btnCancel.Click -= BtnCancel_Click; btnCancel.Click += BtnCancel_Click; }
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
                MessageBox.Show("Name is required.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out int idade))
            {
                MessageBox.Show("Age must be a number.");
                return;
            }

            if (sender is Button btnSender) btnSender.Enabled = false;

            var viewModel = new StudentViewModel
            {
                Id = _editing != null ? _editing.Id : 0,
                Name = txtName.Text.Trim(),
                Age = idade,
                Level = txtLevel.Text.Trim()
            };

            try
            {
                if (_editing == null)
                {
                    await _service.Add<StudentViewModel, StudentViewModel, StudentValidator>(viewModel);
                }
                else
                {
                    await _service.Update<StudentViewModel, StudentViewModel, StudentValidator>(viewModel);
                }

                MessageBox.Show("Saved successfully!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sender is Button btnFinally) btnFinally.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ApplyTheme()
        {
            BackColor = Color.FromArgb(255, 235, 245);
            if (Controls.ContainsKey("panelMain")) Controls["panelMain"].BackColor = Color.White;

            StyleButton(btnSave);
            StyleButton(btnCancel);
        }

        private static void StyleButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = Color.RosyBrown;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.BorderSize = 0;
        }
    }
}