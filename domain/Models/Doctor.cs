using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models 
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Specialization Specialization { get; set; }


        public Doctor() : this(0,"", new Specialization()) { }
        public Doctor(int id, string fullname, Specialization specialization)
        {
            Id = id;
            FullName = fullname;
            Specialization = specialization;
        }

        public Result IsValid()
        {
            if (string.IsNullOrEmpty(FullName))
            {
                return Result.Fail("Non correct name");
            }
            else if (string.IsNullOrEmpty(Specialization.Name))
            {
                return Result.Fail("Non correct specialization name");
            }
            else
            {
                return Result.Ok();
            }
        }
    }
}
