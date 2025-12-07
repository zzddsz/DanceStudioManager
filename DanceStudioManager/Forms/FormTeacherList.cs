using ReaLTaiizor.Forms;
using System;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormTeacherList : Form
    {
        public FormTeacherList()
        {
            InitializeComponent();
        }

        private void FormTeacherList_Load(object sender, EventArgs e)
        {
            Button[] b = { btnAdd, btnEdit, btnDelete, btnRefresh };

            foreach (var btn in b)
            {
                btn.BackColor = System.Drawing.Color.RosyBrown;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                btn.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
