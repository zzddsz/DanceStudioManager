namespace DanceStudioManager
{
    partial class FormAddEditStudent
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelMain;
        private Label lblName;
        private Label lblAge;
        private Label lblLevel;

        private TextBox txtName;
        private TextBox txtAge;
        private TextBox txtLevel;

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblLevel = new Label();
            txtLevel = new TextBox();
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
            panelMain.Controls.Add(lblAge);
            panelMain.Controls.Add(txtAge);
            panelMain.Controls.Add(lblLevel);
            panelMain.Controls.Add(txtLevel);
            panelMain.Controls.Add(btnSave);
            panelMain.Controls.Add(btnCancel);
            panelMain.Location = new Point(20, 20);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(360, 260);
            panelMain.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Font = new Font("Tahoma", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblName.ForeColor = SystemColors.Desktop;
            lblName.Location = new Point(30, 40);
            lblName.Name = "lblName";
            lblName.Size = new Size(57, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(103, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(217, 27);
            txtName.TabIndex = 1;
            // 
            // lblAge
            // 
            lblAge.Font = new Font("Tahoma", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblAge.ForeColor = SystemColors.Desktop;
            lblAge.Location = new Point(30, 90);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(57, 23);
            lblAge.TabIndex = 2;
            lblAge.Text = "Age:";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(103, 88);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(217, 27);
            txtAge.TabIndex = 3;
            // 
            // lblLevel
            // 
            lblLevel.Font = new Font("Tahoma", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = SystemColors.Desktop;
            lblLevel.Location = new Point(30, 140);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(57, 23);
            lblLevel.TabIndex = 4;
            lblLevel.Text = "Level:";
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(103, 138);
            txtLevel.Name = "txtLevel";
            txtLevel.Size = new Size(217, 27);
            txtLevel.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RosyBrown;
            btnSave.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(120, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 32);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(230, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 32);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormAddEditAluno
            // 
            ClientSize = new Size(400, 300);
            Controls.Add(panelMain);
            Name = "FormAddEditAluno";
            Text = "Add / Edit Student";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }
    }
}
