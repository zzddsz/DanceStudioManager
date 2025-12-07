using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    partial class FormAddEditClass
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblNome;
        private TextBox txtNome;

        private Label lblProfessor;
        private TextBox txtProfessor;

        private Label lblDiaSemana;
        private ComboBox cmbDiaSemana;

        private Label lblHorario;
        private DateTimePicker timeHorario;

        private Label lblVagas;
        private NumericUpDown numVagas;

        private Button btnSalvar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNome = new Label();
            txtNome = new TextBox();
            lblProfessor = new Label();
            txtProfessor = new TextBox();
            lblDiaSemana = new Label();
            cmbDiaSemana = new ComboBox();
            lblHorario = new Label();
            timeHorario = new DateTimePicker();
            lblVagas = new Label();
            numVagas = new NumericUpDown();
            btnSalvar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numVagas).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.Location = new Point(20, 20);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(100, 23);
            lblNome.TabIndex = 0;
            lblNome.Text = "Class Name:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(20, 45);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(360, 27);
            txtNome.TabIndex = 1;
            // 
            // lblProfessor
            // 
            lblProfessor.Location = new Point(20, 85);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(100, 23);
            lblProfessor.TabIndex = 2;
            lblProfessor.Text = "Teacher:";
            // 
            // txtProfessor
            // 
            txtProfessor.Location = new Point(20, 110);
            txtProfessor.Name = "txtProfessor";
            txtProfessor.Size = new Size(360, 27);
            txtProfessor.TabIndex = 3;
            // 
            // lblDiaSemana
            // 
            lblDiaSemana.Location = new Point(20, 150);
            lblDiaSemana.Name = "lblDiaSemana";
            lblDiaSemana.Size = new Size(100, 23);
            lblDiaSemana.TabIndex = 4;
            lblDiaSemana.Text = "Day of Week:";
            // 
            // cmbDiaSemana
            // 
            cmbDiaSemana.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiaSemana.Items.AddRange(new object[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            cmbDiaSemana.Location = new Point(20, 175);
            cmbDiaSemana.Name = "cmbDiaSemana";
            cmbDiaSemana.Size = new Size(200, 28);
            cmbDiaSemana.TabIndex = 5;
            // 
            // lblHorario
            // 
            lblHorario.Location = new Point(20, 215);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(100, 23);
            lblHorario.TabIndex = 6;
            lblHorario.Text = "Time:";
            // 
            // timeHorario
            // 
            timeHorario.Format = DateTimePickerFormat.Time;
            timeHorario.Location = new Point(20, 240);
            timeHorario.Name = "timeHorario";
            timeHorario.ShowUpDown = true;
            timeHorario.Size = new Size(200, 27);
            timeHorario.TabIndex = 7;
            // 
            // lblVagas
            // 
            lblVagas.Location = new Point(20, 280);
            lblVagas.Name = "lblVagas";
            lblVagas.Size = new Size(100, 23);
            lblVagas.TabIndex = 8;
            lblVagas.Text = "Max Students:";
            // 
            // numVagas
            // 
            numVagas.Location = new Point(20, 305);
            numVagas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numVagas.Name = "numVagas";
            numVagas.Size = new Size(80, 27);
            numVagas.TabIndex = 9;
            numVagas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(200, 340);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 33);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Save";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(290, 340);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 33);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancel";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAddEditClass
            // 
            BackColor = Color.RosyBrown;
            ClientSize = new Size(420, 400);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblProfessor);
            Controls.Add(txtProfessor);
            Controls.Add(lblDiaSemana);
            Controls.Add(cmbDiaSemana);
            Controls.Add(lblHorario);
            Controls.Add(timeHorario);
            Controls.Add(lblVagas);
            Controls.Add(numVagas);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Name = "FormAddEditClass";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add / Edit Class";
            ((System.ComponentModel.ISupportInitialize)numVagas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}