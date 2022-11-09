using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Models;


namespace domain.Logic
{
    interface IVisitRepository
    {
        bool SaveVisit(Visit visit);

    }
}
