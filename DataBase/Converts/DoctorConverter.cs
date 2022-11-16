using domain.Models;
using DataBase.Models;
using System.Runtime.CompilerServices;

namespace DataBase.Converts
{
    public static class DoctorConverter
    {
        public static Doctor? ToDomain(this DoctorModel model)
        {
            return new Doctor
            {
                Id = model.Id,
                FullName= model.FullName,
                Specialization= model.Specialization
            };
        }

        public static DoctorModel? ToModel(this Doctor model)
        {
            return new DoctorModel
            {
                Id = model.Id,
                FullName = model.FullName,
                Specialization = model.Specialization
            };
        }
    }
}
