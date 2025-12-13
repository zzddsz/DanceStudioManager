using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using DanceStudio.Service.Validators;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormAddEditClass : Form
    {
        private readonly DanceClassService _service;
        private readonly TeacherService _teacherService;
        private DanceClassViewModel _editing;

        public FormAddEditClass(DanceClassService service, TeacherService teacherService)
        {
            _service = service;
            _teacherService = teacherService;
            InitializeComponent();
            ApplyTheme();

            if (btnSalvar != null) { btnSalvar.Click -= btnSalvar_Click; btnSalvar.Click += btnSalvar_Click; }
            if (btnCancelar != null) { btnCancelar.Click -= btnCancelar_Click; btnCancelar.Click += btnCancelar_Click; }

            this.Load -= FormAddEditClass_Load;
            this.Load += FormAddEditClass_Load;
        }

        private async void FormAddEditClass_Load(object sender, EventArgs e)
        {
            await CarregarProfessores();
        }

        private async Task CarregarProfessores()
        {
            try
            {
                var teachers = await _teacherService.Get<TeacherViewModel>();
                if (cmbTeacher != null)
                {
                    cmbTeacher.DataSource = teachers.ToList();
                    cmbTeacher.DisplayMember = "Name";
                    cmbTeacher.ValueMember = "Id";

                    if (_editing != null && _editing.TeacherId != null)
                        cmbTeacher.SelectedValue = _editing.TeacherId;
                    else
                        cmbTeacher.SelectedIndex = -1; // Começa vazio
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar professores: " + ex.Message);
            }
        }

        public void LoadClass(DanceClassViewModel viewModel)
        {
            _editing = viewModel;
            txtNome.Text = viewModel.Name;
            cmbDiaSemana.Text = viewModel.DayOfWeek;
            numVagas.Value = viewModel.MaxStudents;
            try { timeHorario.Value = DateTime.Today.Add(viewModel.Time); } catch { }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validações básicas de tela
            if (string.IsNullOrWhiteSpace(txtNome.Text)) { MessageBox.Show("Nome obrigatório."); return; }
            if (cmbTeacher.SelectedValue == null) { MessageBox.Show("Selecione um Professor."); return; }
            if (string.IsNullOrWhiteSpace(cmbDiaSemana.Text)) { MessageBox.Show("Dia obrigatório."); return; }

            if (sender is Button btnSender) btnSender.Enabled = false;

            try
            {
                var viewModel = new DanceClassViewModel
                {
                    Id = _editing != null ? _editing.Id : 0,
                    Name = txtNome.Text.Trim(),
                    TeacherId = (int)cmbTeacher.SelectedValue, // Pega o ID do Combo
                    DayOfWeek = cmbDiaSemana.Text,
                    Time = timeHorario.Value.TimeOfDay,
                    MaxStudents = (int)numVagas.Value
                };

                // O Service vai usar o AutoMapper (Program.cs) para converter ViewModel -> Entity
                // E depois vai usar o DanceClassValidator (Service) para validar a Entity
                if (_editing == null)
                    await _service.Add<DanceClassViewModel, DanceClassViewModel, DanceClassValidator>(viewModel);
                else
                    await _service.Update<DanceClassViewModel, DanceClassViewModel, DanceClassValidator>(viewModel);

                MessageBox.Show("Salvo com sucesso!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                // Se der erro de validação ou banco, mostra aqui
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
            finally
            {
                if (sender is Button btnFinally) btnFinally.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => Close();

        private void ApplyTheme()
        {
            BackColor = Color.LavenderBlush;
            if (btnSalvar != null) { btnSalvar.BackColor = Color.RosyBrown; btnSalvar.ForeColor = Color.White; btnSalvar.FlatStyle = FlatStyle.Flat; }
            if (btnCancelar != null) { btnCancelar.BackColor = Color.RosyBrown; btnCancelar.ForeColor = Color.White; btnCancelar.FlatStyle = FlatStyle.Flat; }
        }
    }
}