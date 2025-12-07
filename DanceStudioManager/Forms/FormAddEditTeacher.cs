using DanceStudio.Service.DTOs;
using DanceStudioManager.Controllers;
using ReaLTaiizor.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanceStudioManager
{
    public partial class FormAddEditTeacher : Form
    {
        private readonly TeacherController _controller;
        private int? _idEdicao = null;

        public FormAddEditTeacher(TeacherController controller)
        {
            _controller = controller;
            InitializeComponent();
            ApplyTheme();
        }

        public void LoadForEdit(TeacherDTO dto)
        {
            _idEdicao = dto.Id;
            txtName.Text = dto.Name;
            txtSpeciality.Text = dto.Speciality;
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(255, 235, 245);
            this.Font = new Font("Segoe UI", 11);

            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;

            StyleButton(btnSave);
            StyleButton(btnCancel);
        }

        private void StyleButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(255, 170, 200);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 130, 180);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 110, 160);
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            TeacherDTO dto = new TeacherDTO
            {
                Name = txtName.Text.Trim(),
                Speciality = txtSpeciality.Text.Trim()
            };

            bool ok;
            string msg;

            if (_idEdicao == null)
            {
                (ok, msg) = await _controller.Criar(dto);
            }
            else
            {
                dto.Id = _idEdicao.Value;
                (ok, msg) = await _controller.Atualizar(_idEdicao.Value, dto);
            }

            MessageBox.Show(msg);

            if (ok)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
