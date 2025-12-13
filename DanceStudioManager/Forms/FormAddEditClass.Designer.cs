namespace DanceStudioManager.Forms
{
    partial class FormAddEditClass
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.ComboBox cmbTeacher; // Mudado para ComboBox
        private System.Windows.Forms.Label lblDiaSemana;
        private System.Windows.Forms.ComboBox cmbDiaSemana;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.DateTimePicker timeHorario;
        private System.Windows.Forms.Label lblVagas;
        private System.Windows.Forms.NumericUpDown numVagas;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNome = new System.Windows.Forms.Label();
            txtNome = new System.Windows.Forms.TextBox();
            lblProfessor = new System.Windows.Forms.Label();
            cmbTeacher = new System.Windows.Forms.ComboBox();
            lblDiaSemana = new System.Windows.Forms.Label();
            cmbDiaSemana = new System.Windows.Forms.ComboBox();
            lblHorario = new System.Windows.Forms.Label();
            timeHorario = new System.Windows.Forms.DateTimePicker();
            lblVagas = new System.Windows.Forms.Label();
            numVagas = new System.Windows.Forms.NumericUpDown();
            btnSalvar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(numVagas)).BeginInit();
            SuspendLayout();

            // lblNome
            lblNome.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lblNome.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            lblNome.Location = new System.Drawing.Point(20, 20);
            lblNome.Name = "lblNome";
            lblNome.Size = new System.Drawing.Size(100, 23);
            lblNome.Text = "Class Name:";

            // txtNome
            txtNome.Location = new System.Drawing.Point(20, 45);
            txtNome.Name = "txtNome";
            txtNome.Size = new System.Drawing.Size(360, 27);

            // lblProfessor
            lblProfessor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lblProfessor.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            lblProfessor.Location = new System.Drawing.Point(20, 85);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new System.Drawing.Size(100, 23);
            lblProfessor.Text = "Teacher:";

            // cmbTeacher (COMBOBOX)
            cmbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTeacher.Location = new System.Drawing.Point(20, 110);
            cmbTeacher.Name = "cmbTeacher";
            cmbTeacher.Size = new System.Drawing.Size(360, 28);

            // lblDiaSemana
            lblDiaSemana.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lblDiaSemana.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            lblDiaSemana.Location = new System.Drawing.Point(20, 150);
            lblDiaSemana.Name = "lblDiaSemana";
            lblDiaSemana.Size = new System.Drawing.Size(129, 23);
            lblDiaSemana.Text = "Day of Week:";

            // cmbDiaSemana
            cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDiaSemana.Items.AddRange(new object[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            cmbDiaSemana.Location = new System.Drawing.Point(20, 175);
            cmbDiaSemana.Name = "cmbDiaSemana";
            cmbDiaSemana.Size = new System.Drawing.Size(200, 28);

            // lblHorario
            lblHorario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lblHorario.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            lblHorario.Location = new System.Drawing.Point(20, 215);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new System.Drawing.Size(100, 23);
            lblHorario.Text = "Time:";

            // timeHorario
            timeHorario.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            timeHorario.Location = new System.Drawing.Point(20, 240);
            timeHorario.Name = "timeHorario";
            timeHorario.ShowUpDown = true;
            timeHorario.Size = new System.Drawing.Size(200, 27);

            // lblVagas
            lblVagas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lblVagas.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
            lblVagas.Location = new System.Drawing.Point(20, 280);
            lblVagas.Name = "lblVagas";
            lblVagas.Size = new System.Drawing.Size(100, 23);
            lblVagas.Text = "Max Students:";

            // numVagas
            numVagas.Location = new System.Drawing.Point(20, 305);
            numVagas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numVagas.Name = "numVagas";
            numVagas.Size = new System.Drawing.Size(80, 27);
            numVagas.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnSalvar
            btnSalvar.BackColor = System.Drawing.Color.RosyBrown;
            btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnSalvar.Location = new System.Drawing.Point(200, 340);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new System.Drawing.Size(75, 33);
            btnSalvar.Text = "Save";
            btnSalvar.UseVisualStyleBackColor = false;

            // btnCancelar
            btnCancelar.BackColor = System.Drawing.Color.RosyBrown;
            btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            btnCancelar.Location = new System.Drawing.Point(290, 340);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(75, 33);
            btnCancelar.Text = "Cancel";
            btnCancelar.UseVisualStyleBackColor = false;

            // FormAddEditClass
            BackColor = System.Drawing.Color.LavenderBlush;
            ClientSize = new System.Drawing.Size(420, 400);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblProfessor);
            Controls.Add(cmbTeacher);
            Controls.Add(lblDiaSemana);
            Controls.Add(cmbDiaSemana);
            Controls.Add(lblHorario);
            Controls.Add(timeHorario);
            Controls.Add(lblVagas);
            Controls.Add(numVagas);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Name = "FormAddEditClass";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Add / Edit Class";
            ((System.ComponentModel.ISupportInitialize)(numVagas)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}