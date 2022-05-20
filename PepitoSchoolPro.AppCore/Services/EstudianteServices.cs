using PepitoSchoolPro.AppCore.Contracts;
using PepitoSchoolPro.Domain.Contracts;
using PepitoSchoolPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolPro.AppCore.Services
{
    public class EstudianteServices : IEstudianteServices
    {
        private IEstudianteRepository estudianteRepository;

        public EstudianteServices(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }

        public void Create(Estudiante t)
        {
            estudianteRepository.Create(t);
        }

        public bool Delete(Estudiante t)
        {
            estudianteRepository.Delete(t);
            return true;
        }

        public Estudiante FindByCode(string code)
        {
            return estudianteRepository.FindByCode(code);
        }

        public Estudiante FindById(int id)
        {
            return estudianteRepository.FindById(id);
        }

        public List<Estudiante> FindByName(string name)
        {
            return estudianteRepository.FindByName(name);   
        }

        public List<Estudiante> GetAll()
        {
            return estudianteRepository.GetAll();
        }

        public int Update(Estudiante t)
        {
            estudianteRepository.Update(t);
            return 0;
        }
    }
}
