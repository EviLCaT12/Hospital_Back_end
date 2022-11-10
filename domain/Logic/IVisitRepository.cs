using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Models;


namespace domain.Logic
{
    public interface IVisitRepository : IRepository<Visit>
    {
        bool IsVisitExist(Visit visit);
        IEnumerable<DateTime> GetFreeVisitbuSpec(Specialization specialization);
        IEnumerable<DateTime> GetFreeVisitByDoctor(Doctor doctor);
        bool CreateVisit(Visit visit);
    }
}
