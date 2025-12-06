namespace DanceStudioManager.Views
{
    partial class FormAddEditEnrollment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblStudent = new Label();
            cmbStudents = new ComboBox();
            lblClass = new Label();
            cmbClasses = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(lblStudent);
            panelMain.Controls.Add(cmbStudents);
            panelMain.Controls.Add(lblClass);
            panelMain.Controls.Add(cmbClasses);
            panelMain.Controls.Add(lblDate);
            panelMain.Controls.Add(dtpDate);
            panelMain.Controls.Add(btnSave);
            panelMain.Controls.Add(btnCancel);
            panelMain.Location = new Point(41, 55);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(420, 280);
            panelMain.TabIndex = 0;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblStudent.Location = new Point(20, 25);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(69, 22);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Aluno:";
            // 
            // cmbStudents
            // 
            cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudents.Font = new Font("Segoe UI", 11F);
            cmbStudents.Location = new Point(120, 22);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(260, 33);
            cmbStudents.TabIndex = 1;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblClass.Location = new Point(20, 80);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(76, 22);
            lblClass.TabIndex = 2;
            lblClass.Text = "Turma:";
            // 
            // cmbClasses
            // 
            cmbClasses.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClasses.Font = new Font("Segoe UI", 11F);
            cmbClasses.Location = new Point(120, 77);
            cmbClasses.Name = "cmbClasses";
            cmbClasses.Size = new Size(260, 33);
            cmbClasses.TabIndex = 3;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Tahoma", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(20, 135);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(60, 22);
            lblDate.TabIndex = 4;
            lblDate.Text = "Data:";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 11F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(120, 132);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(260, 32);
            dtpDate.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(255, 170, 200);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 130, 180);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(120, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 6;
            btnSave.Text = "Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 170, 200);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 130, 180);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(260, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormAddEditEnrollment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 235, 245);
            ClientSize = new Size(513, 394);
            Controls.Add(panelMain);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormAddEditEnrollment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Matrícula";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
