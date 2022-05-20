using PepitoSchoolPro.AppCore.Processes;
using PepitoSchoolPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolPro.AppCore.Contracts
{
    public interface IStudentAverage
    {
        List<StudentAverage> studentAverages(List<Estudiante> estudiantes);
    }
}
