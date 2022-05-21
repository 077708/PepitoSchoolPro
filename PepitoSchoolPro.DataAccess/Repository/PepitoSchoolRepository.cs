using PepitoSchoolPro.Domain.Contracts;
using PepitoSchoolPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolPro.DataAccess.Repository
{
    public class PepitoSchoolRepository : IEstudianteRepository
    {
        private IPepitoSchoolContext pepitoSchoolContext;

        public PepitoSchoolRepository(IPepitoSchoolContext pepitoSchoolContext)
        {
            this.pepitoSchoolContext = pepitoSchoolContext;
        }

        public void Create(Estudiante t)
        {
            try
            {
                pepitoSchoolContext.Estudiantes.Add(t);
                pepitoSchoolContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool Delete(Estudiante t)
        {

            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Asset no puede ser null.");
                }

                Estudiante asset = FindById(t.Id);
                if (asset == null)
                {
                    throw new Exception($"El objeto con id {t.Id} no existe.");
                }

                pepitoSchoolContext.Estudiantes.Remove(asset);
                int result = pepitoSchoolContext.SaveChanges();

                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante FindByCode(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception($"El parametro code {code} no tiene el formato correcto.");
                }

                return pepitoSchoolContext.Estudiantes.FirstOrDefault(x => x.Carnet.Equals(code));
            }
            catch
            {
                throw;
            }

        }

        public Estudiante FindById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception($"El id {id} no puede ser menor o igual a cero.");
                }

                return pepitoSchoolContext.Estudiantes.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                throw;
            }

        }

        public List<Estudiante> FindByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception($"El parametro name '{name}' no tiene el formato correcto.");
                }

                return pepitoSchoolContext.Estudiantes
                                        .Where(x => x.Nombres.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                                        .ToList();
            }
            catch
            {
                throw;
            }

        }

        public List<Estudiante> GetAll()
        {
            return pepitoSchoolContext.Estudiantes.ToList();
        }

        public int Update(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto asset no puede ser null.");
                }

                Estudiante student = FindById(t.Id);
                if (student == null)
                {
                    throw new Exception($"El objeto asset con id {t.Id} no existe.");
                }

                student.Nombres = t.Nombres;
                student.Direccion= t.Direccion;
                student.Matematica = t.Matematica;
                student.Estadistica= t.Estadistica;
                student.Contabilidad = t.Contabilidad;
                student.Carnet= t.Carnet;
                student.Programacion = t.Programacion;

                pepitoSchoolContext.Estudiantes.Update(student);
                return pepitoSchoolContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
