namespace DanceStudioManager
{
    partial class FormAddEditTeacher
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMain;
        private Label lblName;
        private Label lblSpeciality;
        private TextBox txtName;
        private TextBox txtSpeciality;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            lblSpeciality = new Label();
            txtSpeciality = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lblName);
            panelMain.Controls.Add(txtName);
            panelMain.Controls.Add(lblSpeciality);
            panelMain.Controls.Add(txtSpeciality);
            panelMain.Controls.Add(btnSave);
            panelMain.Controls.Add(btnCancel);
            panelMain.Location = new Point(20, 20);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(360, 230);
            panelMain.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Font = new Font("Tahoma", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblName.Location = new Point(18, 40);
            lblName.Name = "lblName";
            lblName.Size = new Size(89, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 36);
            txtName.Name = "txtName";
            txtName.Size = new Size(216, 27);
            txtName.TabIndex = 1;
            // 
            // lblSpeciality
            // 
            lblSpeciality.Font = new Font("Tahoma", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblSpeciality.Location = new Point(18, 86);
            lblSpeciality.Name = "lblSpeciality";
            lblSpeciality.Size = new Size(100, 23);
            lblSpeciality.TabIndex = 2;
            lblSpeciality.Text = "Speciality:";
            // 
            // txtSpeciality
            // 
            txtSpeciality.Location = new Point(120, 86);
            txtSpeciality.Name = "txtSpeciality";
            txtSpeciality.Size = new Size(216, 27);
            txtSpeciality.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RosyBrown;
            btnSave.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(120, 150);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 41);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(220, 150);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 41);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // FormAddEditTeacher
            // 
            ClientSize = new Size(419, 280);
            Controls.Add(panelMain);
            Name = "FormAddEditTeacher";
            Text = "Add / Edit Teacher";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }
    }
}
