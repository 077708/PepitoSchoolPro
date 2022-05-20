using PepitoSchoolPro.AppCore.Contracts;
using PepitoSchoolPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolPro.AppCore.Processes
{
    public class AverageStudent : IStudentAverage
    {
        public List<StudentAverage> studentAverages(List<Estudiante> estudiantes)
        {
            var studentAverages = new List<StudentAverage>();
            var data = 0;
            foreach (var item in estudiantes)
            {
                data = (estudiantes.Where(p => p.Id == item.Id)
                    .Sum(q => q.Contabilidad + q.Programacion + q.Estadistica + q.Matematica));
                studentAverages.Add(new StudentAverage()
                {
                    Id = item.Id,
                    Name = item.Nombres,
                    Carnet = item.Carnet,
                    Matemática = item.Matematica,
                    Contabilidad = item.Contabilidad,
                    Programación = item.Contabilidad,
                    Estadistica = item.Estadistica,
                    Promedio = $"{data/4}%",
                
                });
            }

            return studentAverages;
        }
    }
}
