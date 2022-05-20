using Microsoft.EntityFrameworkCore;
using PepitoSchoolPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolPro.Domain.Contracts
{
    public interface IPepitoSchoolContext
    {
        DbSet<Estudiante> Estudiantes { get; set; }
        public int SaveChanges();
    }

}
