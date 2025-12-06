using DanceStudio.Service.DTOs;
using DanceStudioManager.Controllers;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager
{
    public partial class FormEnrollmentList : Form
    {
        private readonly EnrollmentController _controller;

        public FormEnrollmentList(EnrollmentController controller)
        {
            _controller = controller;
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(255, 235, 245); // fundo rosa claro
            this.Font = new Font("Segoe UI", 10);

            panelTop.BackColor = Color.White;

            StyleButton(btnAdd);
            StyleButton(btnDelete);
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

        private async void FormEnrollmentList_Load(object sender, EventArgs e)
        {
            await CarregarLista();
        }

        private async Task CarregarLista()
        {
            var lista = await _controller.Listar();
            dgvEnrollments.DataSource = lista;

            dgvEnrollments.Columns["Id"].Visible = false;
            dgvEnrollments.Columns["StudentId"].Visible = false;
            dgvEnrollments.Columns["DanceClassId"].Visible = false;

            dgvEnrollments.Columns["StudentName"].HeaderText = "Aluno";
            dgvEnrollments.Columns["DanceClassName"].HeaderText = "Turma";
            dgvEnrollments.Columns["Date"].HeaderText = "Data";
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FormEnrollmentList(_controller))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    await CarregarLista();
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEnrollments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma matrícula para remover.");
                return;
            }

            int id = (int)dgvEnrollments.SelectedRows[0].Cells["Id"].Value;

            var confirm = MessageBox.Show(
                "Deseja remover esta matrícula?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                var result = await _controller.Remover(id);
                MessageBox.Show(result.msg);

                if (result.ok)
                    await CarregarLista();
            }
        }
    }
}
