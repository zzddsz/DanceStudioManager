namespace DanceStudioManager.Views
{
    partial class FormAddEditEnrollment
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cmbClasses = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.lblStudent);
            this.panelMain.Controls.Add(this.cmbStudents);
            this.panelMain.Controls.Add(this.lblClass);
            this.panelMain.Controls.Add(this.cmbClasses);
            this.panelMain.Controls.Add(this.lblDate);
            this.panelMain.Controls.Add(this.dtpDate);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Location = new System.Drawing.Point(41, 55);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(420, 280);
            this.panelMain.TabIndex = 0;

            // lblStudent
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.lblStudent.Location = new System.Drawing.Point(20, 25);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(88, 22);
            this.lblStudent.TabIndex = 0;
            this.lblStudent.Text = "Student:";

            // cmbStudents
            this.cmbStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudents.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbStudents.Location = new System.Drawing.Point(120, 22);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(260, 33);
            this.cmbStudents.TabIndex = 1;

            // lblClass
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.lblClass.Location = new System.Drawing.Point(20, 80);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(63, 22);
            this.lblClass.TabIndex = 2;
            this.lblClass.Text = "Class:";

            // cmbClasses
            this.cmbClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasses.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbClasses.Location = new System.Drawing.Point(120, 77);
            this.cmbClasses.Name = "cmbClasses";
            this.cmbClasses.Size = new System.Drawing.Size(260, 33);
            this.cmbClasses.TabIndex = 3;

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.lblDate.Location = new System.Drawing.Point(20, 135);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(60, 22);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";

            // dtpDate
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(120, 132);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(260, 32);
            this.dtpDate.TabIndex = 5;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(255, 170, 200);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(255, 170, 200);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(260, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;

            // FormAddEditEnrollment
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 235, 245);
            this.ClientSize = new System.Drawing.Size(513, 394);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAddEditEnrollment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrícula";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}