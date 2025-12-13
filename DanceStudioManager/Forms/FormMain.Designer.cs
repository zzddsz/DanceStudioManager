namespace DanceStudioManager
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Button btnTeachers;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnEnrollments;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnEnrollments = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnTeachers = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panelSidebar.Controls.Add(this.btnEnrollments);
            this.panelSidebar.Controls.Add(this.btnClasses);
            this.panelSidebar.Controls.Add(this.btnStudents);
            this.panelSidebar.Controls.Add(this.btnTeachers);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(15, 25, 15, 0);
            this.panelSidebar.Size = new System.Drawing.Size(230, 600);
            this.panelSidebar.TabIndex = 2;

            // btnEnrollments
            this.btnEnrollments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.btnEnrollments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEnrollments.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEnrollments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnEnrollments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnEnrollments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnrollments.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEnrollments.ForeColor = System.Drawing.Color.White;
            this.btnEnrollments.Location = new System.Drawing.Point(15, 190);
            this.btnEnrollments.Name = "btnEnrollments";
            this.btnEnrollments.Size = new System.Drawing.Size(200, 55);
            this.btnEnrollments.TabIndex = 0;
            this.btnEnrollments.Text = "Scheduling";
            this.btnEnrollments.UseVisualStyleBackColor = false;
            this.btnEnrollments.Click += new System.EventHandler(this.BtnEnrollments_Click);

            // btnClasses
            this.btnClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.btnClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClasses.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClasses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnClasses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasses.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClasses.ForeColor = System.Drawing.Color.White;
            this.btnClasses.Location = new System.Drawing.Point(15, 135);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Size = new System.Drawing.Size(200, 55);
            this.btnClasses.TabIndex = 1;
            this.btnClasses.Text = "Classes";
            this.btnClasses.UseVisualStyleBackColor = false;
            this.btnClasses.Click += new System.EventHandler(this.BtnClasses_Click);

            // btnStudents
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.btnStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudents.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStudents.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnStudents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Location = new System.Drawing.Point(15, 80);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(200, 55);
            this.btnStudents.TabIndex = 2;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.BtnStudents_Click);

            // btnTeachers
            this.btnTeachers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.btnTeachers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTeachers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTeachers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnTeachers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeachers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTeachers.ForeColor = System.Drawing.Color.White;
            this.btnTeachers.Location = new System.Drawing.Point(15, 25);
            this.btnTeachers.Name = "btnTeachers";
            this.btnTeachers.Size = new System.Drawing.Size(200, 55);
            this.btnTeachers.TabIndex = 3;
            this.btnTeachers.Text = "Teachers";
            this.btnTeachers.UseVisualStyleBackColor = false;
            this.btnTeachers.Click += new System.EventHandler(this.BtnTeachers_Click);

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(230, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(770, 90);
            this.panelHeader.TabIndex = 1;

            // lblTitle
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Elephant", 19.8000011F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(767, 62);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dance Studio Manager";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // panelContent
            this.panelContent.BackColor = System.Drawing.Color.MistyRose;
            this.panelContent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelContent.BackgroundImage")));
            this.panelContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(230, 90);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(770, 510);
            this.panelContent.TabIndex = 0;

            // FormMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dance Studio Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}