using PepitoSchoolPro.AppCore.Contracts;
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
    public partial class FrmStudents : Form
    {
        private IEstudianteServices studentServices;
        public FrmStudents(IEstudianteServices services)
        {
            this.studentServices = services;
            InitializeComponent();
        }
    }
}
