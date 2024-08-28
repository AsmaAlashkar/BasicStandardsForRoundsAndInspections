using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.HospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class HospitalRepository:IHospitalRepository
    {
        private readonly ApplicationDbContext _context;

        public HospitalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IndexHospitalDTO> GetAllHospitalsNames()
        {
            return _context.Hospitals.Select(i => new IndexHospitalDTO
            {
                Id = i.Id,
                Code = i.Code,
                Name = i.Name,
                NameAr=i.NameAr
            }).ToList();
        }

        public IndexHospitalDTO getHospitalNameById(int id)
        {
            return _context.Hospitals
                .Where(h => h.Id == id)
                .Select(h => new IndexHospitalDTO
                {
                    Name = h.Name,
                    NameAr = h.NameAr
                })
                .FirstOrDefault() ?? new IndexHospitalDTO { Name = "Unknown", NameAr = "غير معروف" };
        }
    }
}
