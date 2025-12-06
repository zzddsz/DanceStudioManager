using System;
using System.Drawing;
using System.Windows.Forms;

using DanceStudioManager.Controllers;
using DanceStudio.Service.DTOs;
using ReaLTaiizor.Forms;

namespace DanceStudioManager
{
    public partial class FormAddEditStudent : Form
    {
        private readonly DanceClassController _controller;

        public FormAddEditStudent(DanceClassController controller)
        {
            _controller = controller;
            InitializeComponent();
            ApplyTheme();
        }

        public void LoadForEdit(string name, int age, string level)
        {
            txtName.Text = name;
            txtAge.Text = age.ToString();
            txtLevel.Text = level;
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(255, 235, 245);

            this.Font = new Font("Segoe UI", 11);

            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;

            foreach (Control c in this.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(180, 60, 120);
                    lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }
            }

            StyleButton(btnSave);
            StyleButton(btnCancel);
        }

        private static void StyleButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(255, 170, 200);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 130, 180);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 110, 160);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal void LoadForEdit(DanceClassDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
