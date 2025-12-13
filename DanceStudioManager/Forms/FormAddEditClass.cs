using DanceStudio.Service.Services;
using DanceStudioManager.ViewModel;
using DanceStudio.Service.Validators;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormAddEditClass : Form
    {
        private readonly DanceClassService _service;
        private DanceClassViewModel _editing;

        public FormAddEditClass(DanceClassService service)
        {
            _service = service;
            InitializeComponent();
            ApplyTheme();
        }

        public void LoadClass(DanceClassViewModel viewModel)
        {
            _editing = viewModel;
            txtNome.Text = viewModel.Name;
            txtProfessor.Text = viewModel.Teacher;
            cmbDiaSemana.Text = viewModel.DayOfWeek;

            try
            {
                timeHorario.Value = DateTime.Today.Add(viewModel.Time);
            }
            catch
            {
                timeHorario.Value = DateTime.Now;
            }

            numVagas.Value = viewModel.MaxStudents;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtProfessor.Text) ||
                string.IsNullOrWhiteSpace(cmbDiaSemana.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!");
                return;
            }

            btnSalvar.Enabled = false;

            try
            {
                var viewModel = new DanceClassViewModel
                {
                    Id = _editing != null ? _editing.Id : 0,
                    Name = txtNome.Text,
                    Teacher = txtProfessor.Text,
                    DayOfWeek = cmbDiaSemana.Text,
                    Time = timeHorario.Value.TimeOfDay,
                    MaxStudents = (int)numVagas.Value
                };


                if (_editing == null)
                {
                    await _service.Add<DanceClassViewModel, DanceClassViewModel, DanceClassValidator>(viewModel);
                }
                else
                {
                   
                    await _service.Update<DanceClassViewModel, DanceClassViewModel, DanceClassValidator>(viewModel);
                }

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSalvar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.LavenderBlush;

            if (btnSalvar != null)
            {
                btnSalvar.BackColor = Color.RosyBrown;
                btnSalvar.ForeColor = Color.White;
            }
            if (btnCancelar != null)
            {
                btnCancelar.BackColor = Color.RosyBrown;
                btnCancelar.ForeColor = Color.White;
            }
        }
    }
}