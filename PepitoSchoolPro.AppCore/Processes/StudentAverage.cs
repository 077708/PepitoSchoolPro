using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolPro.AppCore.Processes
{
    public class StudentAverage
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Carnet { get; set; }
        public int Matemática { get; set; }
        public int Contabilidad { get; set; }
        public int Programación { get; set; }
        public int Estadistica { get; set; }
        public string Promedio { get; set; }
    }
}
