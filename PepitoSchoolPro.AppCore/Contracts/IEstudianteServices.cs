using PepitoSchoolPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolPro.AppCore.Contracts
{
    public interface IEstudianteServices : IServices<Estudiante>
    {
        Estudiante FindById(int id);
        Estudiante FindByCode(string code);
        List<Estudiante> FindByName(string name);
    }
}
