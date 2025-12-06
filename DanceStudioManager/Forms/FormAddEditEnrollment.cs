using DanceStudio.Service.DTOs;
using DanceStudioManager.Controllers;
using ReaLTaiizor.Forms;
using System;
using System.Windows.Forms;

namespace DanceStudioManager.Views
{
    public partial class FormAddEditEnrollment : Form
    {
        private readonly EnrollmentController _controller;
        private readonly StudentController _studentController;
        private readonly DanceClassController _classController;

        private readonly int? _editId;

        public FormAddEditEnrollment(
            EnrollmentController controller,
            StudentController studentController,
            DanceClassController classController,
            int? id = null)
        {
            InitializeComponent();
            _controller = controller;
            _studentController = studentController;
            _classController = classController;
            _editId = id;

            CarregarCombos();

            if (id != null)
                CarregarDados(id.Value);
        }

        // ==========================
        // Carregar combos
        // ==========================
        private async void CarregarCombos()
        {
            var alunos = await _studentController.Listar();
            cmbStudents.DataSource = alunos;
            cmbStudents.DisplayMember = "Name";
            cmbStudents.ValueMember = "Id";

            var classes = await _classController.Listar();
            cmbClasses.DataSource = classes;
            cmbClasses.DisplayMember = "Name";
            cmbClasses.ValueMember = "Id";
        }

        // ==========================
        // Carregar dados ao editar
        // ==========================
        private async void CarregarDados(int id)
        {
            var lista = await _controller.Listar();
            var dto = lista.Find(x => x.Id == id);
            if (dto == null) return;

            cmbStudents.SelectedValue = dto.StudentId;
            cmbClasses.SelectedValue = dto.DanceClassId;
            dtpDate.Value = dto.Date;
        }

        // ==========================
        // Botão Salvar
        // ==========================
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var dto = new EnrollmentDTO
            {
                Id = _editId ?? 0,
                StudentId = (int)cmbStudents.SelectedValue,
                DanceClassId = (int)cmbClasses.SelectedValue,
                Date = dtpDate.Value
            };

            var result = await _controller.Criar(dto);

            if (!result.ok)
            {
                MessageBox.Show(result.msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Matrícula salva com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        // ==========================
        // Botão Cancelar
        // ==========================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
