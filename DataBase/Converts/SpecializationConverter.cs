using domain.Models;
using DataBase.Models;
using System.Runtime.CompilerServices;

namespace DataBase.Converts
{
    public static class SpecializationConverter
    {
        public static Specialization ToDomain(this SpecializationModel model)
        {
            return new Specialization
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static SpecializationModel ToModel(this Specialization model)
        {
            return new SpecializationModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
