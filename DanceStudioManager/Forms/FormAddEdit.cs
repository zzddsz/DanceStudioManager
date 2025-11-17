using System;
using System.Drawing;
using System.Windows.Forms;

// Adicione o using correto para DanceClassController
using DanceStudioManager.Controllers;
using DanceStudioManager.DTOs; // Altere para o namespace correto onde DanceClassController está definido

namespace DanceStudioManager
{
    public partial class FormAddEdit : Form
    {
        private readonly DanceClassController _controller;

        // Adicione este construtor para aceitar DanceClassController
        public FormAddEdit(DanceClassController controller)
        {
            _controller = controller;
            InitializeComponent();
            ApplyTheme();
        }

        // --- CARREGA DADOS PARA EDIÇÃO ---
        public void LoadForEdit(string name, int age, string level)
        {
            txtName.Text = name;
            txtAge.Text = age.ToString();
            txtLevel.Text = level;
        }

        private void ApplyTheme()
        {
            // Fundo rosa claro
            this.BackColor = Color.FromArgb(255, 235, 245);

            // Fonte geral estilosa
            this.Font = new Font("Segoe UI", 11);

            // Painel container
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;

            // Labels
            foreach (Control c in this.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(180, 60, 120);
                    lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }
            }

            // Botões
            StyleButton(btnSave);
            StyleButton(btnCancel);
        }

        // CA1822: Torne o método estático
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

        // IDE1006: Corrija a nomenclatura dos métodos de evento
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
