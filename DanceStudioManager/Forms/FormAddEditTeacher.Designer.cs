namespace DanceStudioManager.Forms
{
    partial class FormAddEditTeacher
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSpecialty; // Corrigido
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSpecialty; // Corrigido
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSpecialty = new System.Windows.Forms.Label();
            this.txtSpecialty = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.lblName);
            this.panelMain.Controls.Add(this.txtName);
            this.panelMain.Controls.Add(this.lblSpecialty);
            this.panelMain.Controls.Add(this.txtSpecialty);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Location = new System.Drawing.Point(20, 20);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(360, 230);
            this.panelMain.TabIndex = 0;

            // lblName
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.lblName.Location = new System.Drawing.Point(18, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(216, 23);
            this.txtName.TabIndex = 1;

            // lblSpecialty
            this.lblSpecialty.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.lblSpecialty.Location = new System.Drawing.Point(18, 86);
            this.lblSpecialty.Name = "lblSpecialty";
            this.lblSpecialty.Size = new System.Drawing.Size(100, 23);
            this.lblSpecialty.TabIndex = 2;
            this.lblSpecialty.Text = "Specialty:";

            // txtSpecialty
            this.txtSpecialty.Location = new System.Drawing.Point(120, 86);
            this.txtSpecialty.Name = "txtSpecialty";
            this.txtSpecialty.Size = new System.Drawing.Size(216, 23);
            this.txtSpecialty.TabIndex = 3;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(120, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 41);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.RosyBrown;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(220, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 41);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;

            // FormAddEditTeacher
            this.ClientSize = new System.Drawing.Size(419, 280);
            this.Controls.Add(this.panelMain);
            this.Name = "FormAddEditTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Teacher";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}