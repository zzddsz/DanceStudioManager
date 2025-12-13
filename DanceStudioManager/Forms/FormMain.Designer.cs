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
            panelSidebar = new Panel();
            btnEnrollments = new Button();
            btnClasses = new Button();
            btnStudents = new Button();
            btnTeachers = new Button();
            panelHeader = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
            panelSidebar.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(115, 55, 55);
            panelSidebar.Controls.Add(btnEnrollments);
            panelSidebar.Controls.Add(btnClasses);
            panelSidebar.Controls.Add(btnStudents);
            panelSidebar.Controls.Add(btnTeachers);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Padding = new Padding(15, 25, 15, 0);
            panelSidebar.Size = new Size(230, 600);
            panelSidebar.TabIndex = 2;
            // 
            // btnEnrollments
            // 
            btnEnrollments.BackColor = Color.FromArgb(195, 145, 145);
            btnEnrollments.Dock = DockStyle.Top;
            btnEnrollments.FlatAppearance.BorderColor = Color.White;
            btnEnrollments.FlatAppearance.MouseDownBackColor = Color.FromArgb(175, 125, 125);
            btnEnrollments.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 165, 165);
            btnEnrollments.FlatStyle = FlatStyle.Flat;
            btnEnrollments.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEnrollments.ForeColor = Color.White;
            btnEnrollments.Location = new Point(15, 190);
            btnEnrollments.Name = "btnEnrollments";
            btnEnrollments.Size = new Size(200, 55);
            btnEnrollments.TabIndex = 0;
            btnEnrollments.Text = "Scheduling";
            btnEnrollments.UseVisualStyleBackColor = false;
            btnEnrollments.Click += BtnEnrollments_Click;
            // 
            // btnClasses
            // 
            btnClasses.BackColor = Color.FromArgb(195, 145, 145);
            btnClasses.Dock = DockStyle.Top;
            btnClasses.FlatAppearance.BorderColor = Color.White;
            btnClasses.FlatAppearance.MouseDownBackColor = Color.FromArgb(175, 125, 125);
            btnClasses.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 165, 165);
            btnClasses.FlatStyle = FlatStyle.Flat;
            btnClasses.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClasses.ForeColor = Color.White;
            btnClasses.Location = new Point(15, 135);
            btnClasses.Name = "btnClasses";
            btnClasses.Size = new Size(200, 55);
            btnClasses.TabIndex = 1;
            btnClasses.Text = "Classes";
            btnClasses.UseVisualStyleBackColor = false;
            btnClasses.Click += BtnClasses_Click;
            // 
            // btnStudents
            // 
            btnStudents.BackColor = Color.FromArgb(195, 145, 145);
            btnStudents.Dock = DockStyle.Top;
            btnStudents.FlatAppearance.BorderColor = Color.White;
            btnStudents.FlatAppearance.MouseDownBackColor = Color.FromArgb(175, 125, 125);
            btnStudents.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 165, 165);
            btnStudents.FlatStyle = FlatStyle.Flat;
            btnStudents.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStudents.ForeColor = Color.White;
            btnStudents.Location = new Point(15, 80);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(200, 55);
            btnStudents.TabIndex = 2;
            btnStudents.Text = "Students";
            btnStudents.UseVisualStyleBackColor = false;
            btnStudents.Click += BtnStudents_Click;
            // 
            // btnTeachers
            // 
            btnTeachers.BackColor = Color.FromArgb(195, 145, 145);
            btnTeachers.Dock = DockStyle.Top;
            btnTeachers.FlatAppearance.BorderColor = Color.White;
            btnTeachers.FlatAppearance.MouseDownBackColor = Color.FromArgb(175, 125, 125);
            btnTeachers.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 165, 165);
            btnTeachers.FlatStyle = FlatStyle.Flat;
            btnTeachers.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTeachers.ForeColor = Color.White;
            btnTeachers.Location = new Point(15, 25);
            btnTeachers.Name = "btnTeachers";
            btnTeachers.Size = new Size(200, 55);
            btnTeachers.TabIndex = 3;
            btnTeachers.Text = "Teachers";
            btnTeachers.UseVisualStyleBackColor = false;
            btnTeachers.Click += BtnTeachers_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(115, 55, 55);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(230, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(770, 90);
            panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(767, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dance Studio Manager";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.MistyRose;
            panelContent.BackgroundImage = (Image)resources.GetObject("panelContent.BackgroundImage");
            panelContent.BackgroundImageLayout = ImageLayout.Stretch;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(230, 90);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(770, 510);
            panelContent.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 600);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dance Studio Manager";
            Load += FormMain_Load;
            panelSidebar.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
    }
}