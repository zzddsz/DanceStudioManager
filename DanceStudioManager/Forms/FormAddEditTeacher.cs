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
        private int? _idEdicao = null;

        public FormAddEditTeacher(TeacherService service)
        {
            _service = service;
            InitializeComponent();
            ApplyTheme();

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public void LoadForEdit(TeacherViewModel dto)
        {
            _idEdicao = dto.Id;
            txtName.Text = dto.Name;
            txtSpeciality.Text = dto.Specialty;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nome é obrigatório.");
                return;
            }

            var dto = new TeacherViewModel
            {
                Id = _idEdicao ?? 0,
                Name = txtName.Text.Trim(),
                Specialty = txtSpeciality.Text.Trim()
            };

            try
            {
                if (_idEdicao == null)
                {
                    await _service.Add<TeacherViewModel, TeacherViewModel, TeacherValidator>(dto);
                }
                else
                {
                    await _service.Update<TeacherViewModel, TeacherViewModel, TeacherValidator>(dto);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar: " + ex.Message,
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

            if (Controls.ContainsKey("panelMain"))
                Controls["panelMain"].BackColor = Color.White;

            StyleButton(btnSave);
            StyleButton(btnCancel);
        }

        private static void StyleButton(Button btn)
        {
            if (btn == null) return;

            btn.BackColor = Color.RosyBrown;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
        }
    }
}
