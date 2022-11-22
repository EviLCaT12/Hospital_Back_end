using domain.Logic;
using domain.Models;
using DataBase.Converts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    internal class SpecializationRepo : IRepository<Specialization>
    {
        private readonly ApplicationContext _context;

        public SpecializationRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Specialization item)
        {
            _context.Specializations.Add(item.ToModel());
            return true;
        }

        public bool Delete(Specialization item)
        {
            var spec = _context.Specializations.FirstOrDefault(s => s.Id == item.Id);
            if (spec != null)
            {
                _context.Specializations.Remove(spec);
                return true;
            }
            return false;
        }

        public IEnumerable<Specialization> GetAllItem()
        {
            var _specs = _context.Specializations.ToList();
            var specs = _specs.Select(s => s.ToDomain()).ToList();
            return specs;
        }

        public Specialization? GetItemById(int id)
        {
            var spec = _context.Specializations.FirstOrDefault(s => s.Id == id);
            return spec?.ToDomain();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Specialization item)
        {
            _context.Specializations.Update(item.ToModel());
            return true;
        }
    }
}
