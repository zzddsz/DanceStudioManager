using DanceStudioManager.Controllers;
using DanceStudio.Service.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceStudioManager.Forms
{
    public partial class FormAddEditClass : Form
    {
        private readonly DanceClassController _controller;
        private DanceClassDTO _editing;

        public FormAddEditClass(DanceClassController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        public void LoadClass(DanceClassDTO danceClassDto)
        {
            _editing = danceClassDto;
            txtNome.Text = danceClassDto.Name;
            txtProfessor.Text = danceClassDto.Teacher;
            cmbDiaSemana.Text = danceClassDto.DayOfWeek;

            try
            {
                timeHorario.Value = DateTime.Today.Add(danceClassDto.Time);
            }
            catch
            {
                timeHorario.Value = DateTime.Now;
            }

            numVagas.Value = danceClassDto.MaxStudents;
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
                var dto = new DanceClassDTO
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
                   
                    await _controller.Add(dto);
                }
                else
                {
                    var resultado = await _controller.Atualizar(dto.Id, dto);
                    if (!resultado.ok)
                    {
                        MessageBox.Show("Erro ao atualizar: " + resultado.msg);
                        btnSalvar.Enabled = true;
                        return;
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
                btnSalvar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}