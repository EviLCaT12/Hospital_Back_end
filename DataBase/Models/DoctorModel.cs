using domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Specialization Specialization { get; set; }
    }
}
