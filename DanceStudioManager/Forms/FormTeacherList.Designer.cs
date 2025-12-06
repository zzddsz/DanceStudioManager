namespace DanceStudioManager.Forms
{
    partial class FormTeacherList
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel topPanel;

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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.Location = new System.Drawing.Point(20, 150);
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(820, 360);

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(40, 90);
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.Text = "Add";

            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(230, 90);
            this.btnEdit.Size = new System.Drawing.Size(150, 40);
            this.btnEdit.Text = "Edit";

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(420, 90);
            this.btnDelete.Size = new System.Drawing.Size(150, 40);
            this.btnDelete.Text = "Delete";

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(610, 90);
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.Text = "Refresh";

            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.RosyBrown;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Size = new System.Drawing.Size(860, 70);
            this.topPanel.Controls.Add(this.lblTitle);

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "Teachers • Control";

            // 
            // FormTeacherList
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(860, 530);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teachers";
            this.Load += new System.EventHandler(this.FormTeacherList_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
    }
}
