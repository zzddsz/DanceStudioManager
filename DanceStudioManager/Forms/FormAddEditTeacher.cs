using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using DanceStudio.Service.Validators;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormAddEditTeacher : Form
    {
        private readonly TeacherService _service;
        private int? _editId = null;

        public FormAddEditTeacher(TeacherService service)
        {
            _service = service;
            InitializeComponent();
            ApplyTheme();

            if (btnSave != null) { btnSave.Click -= BtnSave_Click; btnSave.Click += BtnSave_Click; }
            if (btnCancel != null) { btnCancel.Click -= BtnCancel_Click; btnCancel.Click += BtnCancel_Click; }
        }

        public void LoadForEdit(TeacherViewModel dto)
        {
            _editId = dto.Id;
            txtName.Text = dto.Name;
            txtSpecialty.Text = dto.Specialty;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return;

            // 1. Usa nome único para evitar erro de variável 'b'
            if (sender is Button btnSender) btnSender.Enabled = false;

            var dto = new TeacherViewModel {
                Id = _editId ?? 0,
                Name = txtName.Text.Trim(),
                Specialty = txtSpecialty.Text.Trim()
            };

            try
            {
                if (_editId == null) await _service.Add<TeacherViewModel, TeacherViewModel, TeacherValidator>(dto);
                else await _service.Update<TeacherViewModel, TeacherViewModel, TeacherValidator>(dto);

                MessageBox.Show("Salvo!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                // 2. Usa nome único para evitar erro de variável 'b'
                if (sender is Button btnFinally) btnFinally.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();

        private void ApplyTheme()
        {
            BackColor = Color.FromArgb(255, 235, 245);
            if (btnSave != null) { btnSave.BackColor = Color.RosyBrown; btnSave.ForeColor = Color.White; btnSave.FlatStyle = FlatStyle.Flat; }
            if (btnCancel != null) { btnCancel.BackColor = Color.RosyBrown; btnCancel.ForeColor = Color.White; btnCancel.FlatStyle = FlatStyle.Flat; }
        }
    }
}