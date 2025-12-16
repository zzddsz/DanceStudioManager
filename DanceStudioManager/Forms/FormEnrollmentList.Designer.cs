namespace DanceStudioManager
{
    partial class FormEnrollmentList
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvEnrollments;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTop = new Panel();
            btnAdd = new Button();
            btnDelete = new Button();
            dgvEnrollments = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnrollments).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(128, 64, 64);
            panelTop.Controls.Add(btnAdd);
            panelTop.Controls.Add(btnDelete);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(800, 80);
            panelTop.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top;
            btnAdd.Location = new Point(163, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(235, 52);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Enrollment";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top;
            btnDelete.Location = new Point(424, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(242, 52);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Remove Enrollment";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvEnrollments
            // 
            dgvEnrollments.AllowUserToAddRows = false;
            dgvEnrollments.AllowUserToDeleteRows = false;
            dgvEnrollments.AllowUserToResizeRows = false;
            dgvEnrollments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnrollments.BackgroundColor = Color.White;
            dgvEnrollments.BorderStyle = BorderStyle.None;
            dgvEnrollments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(128, 64, 64);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvEnrollments.DefaultCellStyle = dataGridViewCellStyle1;
            dgvEnrollments.Dock = DockStyle.Fill;
            dgvEnrollments.Location = new Point(0, 80);
            dgvEnrollments.MultiSelect = false;
            dgvEnrollments.Name = "dgvEnrollments";
            dgvEnrollments.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEnrollments.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEnrollments.RowHeadersVisible = false;
            dgvEnrollments.RowHeadersWidth = 51;
            dgvEnrollments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnrollments.Size = new Size(800, 370);
            dgvEnrollments.TabIndex = 1;
            // 
            // FormEnrollmentList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvEnrollments);
            Controls.Add(panelTop);
            Name = "FormEnrollmentList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciar Matrículas";
            panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEnrollments).EndInit();
            ResumeLayout(false);
        }
    }
}