using PepitoSchoolPro.AppCore.Contracts;
using PepitoSchoolPro.AppCore.Processes;
using PepitoSchoolPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchoolPro.Forms
{
    public partial class FrmAverage : Form
    {
        IStudentAverage studentAverage;
        public FrmAverage(List<Estudiante> estudiantes)
        {
            InitializeComponent();
            studentAverage = new AverageStudent();
            dtgvData.DataSource = studentAverage.studentAverages(estudiantes);
        }
    }
}
