using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using DanceStudio.Service.Validators;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DanceStudioManager.Views
{
    public partial class FormAddEditEnrollment : Form
    {
        private readonly EnrollmentService _service;
        private readonly StudentService _studentService;
        private readonly DanceClassService _classService;
        private readonly int? _editId;

        public FormAddEditEnrollment(
            EnrollmentService service,
            StudentService studentService,
            DanceClassService classService,
            int? id = null)
        {
            InitializeComponent();
            _service = service;
            _studentService = studentService;
            _classService = classService;
            _editId = id;

            if (btnSave != null)
            {
                btnSave.BackColor = Color.FromArgb(255, 170, 200);
                btnSave.Click -= btnSave_Click;
                btnSave.Click += btnSave_Click;
            }
            if (btnCancel != null)
            {
                btnCancel.BackColor = Color.FromArgb(255, 170, 200);
                btnCancel.Click -= btnCancel_Click;
                btnCancel.Click += btnCancel_Click;
            }

            this.Load -= FormAddEditEnrollment_Load;
            this.Load += FormAddEditEnrollment_Load;
        }

        private async void FormAddEditEnrollment_Load(object sender, EventArgs e)
        {
            await CarregarCombos();
        }

        private async Task CarregarCombos()
        {
            try
            {
                var listaAlunos = await _studentService.Get<StudentViewModel>();
                var listaAulas = await _classService.Get<DanceClassViewModel>();

                if (listaAlunos != null)
                {
                    cmbStudents.DataSource = listaAlunos.ToList();
                    cmbStudents.DisplayMember = "Name";
                    cmbStudents.ValueMember = "Id";
                }

                if (listaAulas != null)
                {
                    cmbClasses.DataSource = listaAulas.ToList();
                    cmbClasses.DisplayMember = "Name";
                    cmbClasses.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedValue == null || cmbClasses.SelectedValue == null)
            {
                MessageBox.Show("Selecione Aluno e Aula.");
                return;
            }

            if (sender is Button btnSender) btnSender.Enabled = false;

            var dto = new EnrollmentViewModel
            {
                Id = _editId ?? 0,
                StudentId = (int)cmbStudents.SelectedValue,
                DanceClassId = (int)cmbClasses.SelectedValue,
                Date = dtpDate.Value
            };

            try
            {
                if (_editId == null)
                    await _service.Add<EnrollmentViewModel, EnrollmentViewModel, EnrollmentValidator>(dto);
                else
                    await _service.Update<EnrollmentViewModel, EnrollmentViewModel, EnrollmentValidator>(dto);

                MessageBox.Show("Salvo com sucesso!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                if (sender is Button btnFinally) btnFinally.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}