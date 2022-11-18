using domain.Models;
using DataBase.Models;
using System.Runtime.CompilerServices;

namespace DataBase.Converts
{
    public static class VisitConverter
    {
        public static Visit? ToDomain(this VisitModel model)
        {
            return new Visit
            {
                Id = model.Id,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                UserId = model.UserId,
                DoctorId = model.DoctorId
            };
        }

        public static VisitModel? ToModel(this Visit model)
        {
            return new VisitModel
            {
                Id = model.Id,
                TimeStart = model.TimeStart,
                TimeEnd = model.TimeEnd,
                UserId = model.UserId,
                DoctorId = model.DoctorId
            };
        }
    }
}
