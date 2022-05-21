using PepitoSchoolPro.AppCore.Contracts;
using PepitoSchoolPro.Domain.Entities;
using PepitoSchoolPro.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace PepitoSchoolPro.Forms
{
    public partial class FrmStudents : Form
    {
        private IEstudianteServices studentServices;
        public FrmStudents(IEstudianteServices services)
        {
            this.studentServices = services;
            InitializeComponent();
            Charge();
        }

        private void Charge()
        {
            dtgvData.DataSource = studentServices.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Validations.Validation(txtName.Texts, txtLastNames.Texts, txtCarnet.Texts
                , txtPhone.Texts, txtAddress.Texts, txtEmail.Texts, txtMat.Texts, txtContabilidad.Texts
                , txtProgramacion.Texts, txtStadistics.Texts);

                Estudiante student = new Estudiante()
                {
                    Nombres = txtName.Texts,
                    Apellidos = txtLastNames.Texts,
                    Carnet = txtCarnet.Texts,
                    Phone = txtPhone.Texts,
                    Direccion = txtAddress.Texts,
                    Correo = txtEmail.Texts,
                    Matematica = int.Parse(txtMat.Texts),
                    Contabilidad = int.Parse(txtContabilidad.Texts),
                    Programacion = int.Parse(txtProgramacion.Texts),
                    Estadistica = int.Parse(txtStadistics.Texts)

                };

                studentServices.Create(student);
                Charge();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            FrmAverage frmAverage = new FrmAverage(studentServices.GetAll());
            frmAverage.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                if ((int)dtgvData.Rows.Count > 0)
                    id = id = (int)dtgvData.Rows[dtgvData.CurrentRow.Index].Cells[0].Value;
                else
                    return;

                if (id == 0)
                {
                    return;
                }

                Validations.Validation(txtName.Texts, txtLastNames.Texts, txtCarnet.Texts
                          , txtPhone.Texts, txtAddress.Texts, txtEmail.Texts, txtMat.Texts, txtContabilidad.Texts
                          , txtProgramacion.Texts, txtStadistics.Texts);


                Estudiante student = new Estudiante()
                {
                    Id = id,
                    Nombres = txtName.Texts,
                    Apellidos = txtLastNames.Texts,
                    Carnet = txtCarnet.Texts,
                    Phone = txtPhone.Texts,
                    Direccion = txtAddress.Texts,
                    Correo = txtEmail.Texts,
                    Matematica = int.Parse(txtMat.Texts),
                    Contabilidad = int.Parse(txtContabilidad.Texts),
                    Programacion = int.Parse(txtProgramacion.Texts),
                    Estadistica = int.Parse(txtStadistics.Texts)

                };

                studentServices.Update(student);
                Charge();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                int id = 0;
                if ((int)dtgvData.Rows.Count > 0)
                    id = id = (int)dtgvData.Rows[dtgvData.CurrentRow.Index].Cells[0].Value;
                else
                    return;

                if (id == 0)
                {
                    return;
                }

                studentServices.Delete(studentServices.FindById(id));

                Charge();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFilter__TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFilter.Texts))
                {
                    dtgvData.DataSource = studentServices.GetAll();
                    return;
                }

                DataTable dt = ConvertToDataTable();
                dt.DefaultView.RowFilter = string.Format("Nombres LIKE '*{0}*' OR Id = '{0}'", txtFilter.Texts);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dtgvData.DataSource = bs;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertToDataTable()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dtgvData.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dtgvData.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            return dt;
        }
    }
}
