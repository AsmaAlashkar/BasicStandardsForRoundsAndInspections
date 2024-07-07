using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class SubStandardRepository : ISubStandardRepository
    {
        private readonly ApplicationDbContext _context;

        public SubStandardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public SubStandard CreateSubStandard(CreateSubStandardDTO createSubStandardDTO)
        {
            var mainStandardExists = _context.MainStandards.Any(x=> x.Id == createSubStandardDTO.MainStandardId);
            if (mainStandardExists)
            {
                var newSubStandard = new SubStandard
                {
                    Description = createSubStandardDTO.Description,
                    DescriptionAr = createSubStandardDTO.DescriptionAr,
                    Code = createSubStandardDTO.Code,
                    MainStandardId = createSubStandardDTO.MainStandardId
                };
                _context.Add(newSubStandard);
                _context.SaveChanges();
                return newSubStandard;
            }
            return null;
        }

        public IndexSubStandardDTO GetSubStandardById(int id)
        {
            var subStandard = _context.SubStandards.Find(id);
            if (subStandard != null)
            {
                var subStandardDTO = new IndexSubStandardDTO
                {
                    Description = subStandard.Description,
                    DescriptionAr = subStandard.DescriptionAr,
                    Code = subStandard.Code,
                    MainStandardId = subStandard.MainStandardId
                };
                return subStandardDTO;
            }
            return null;
        }

        public IEnumerable<SubStandard> GetAllSubStandards()
        {
            return _context.SubStandards.OrderBy(s=>s.Id);
        }

        public IEnumerable<IndexSubStandardDTO> GetSubStandardsByMainStandardId(int mainStandardId)
        {
            return _context.SubStandards.Where(s=>s.MainStandardId == mainStandardId).ToList().Select(item=> new IndexSubStandardDTO
            {
                Description= item.Description,
                DescriptionAr= item.DescriptionAr,
                Code= item.Code,
                MainStandardId = item.MainStandardId
            });   
        }

        public SubStandard EditSubStandardById(int id, EditSubStandardDTO editSubStandardDTO)
        {
            var subStandardObj = _context.SubStandards.Find(id);
            if (subStandardObj != null)
            {
                subStandardObj.Description = editSubStandardDTO.Description;
                subStandardObj.Code = editSubStandardDTO.Code;
                subStandardObj.DescriptionAr = editSubStandardDTO.DescriptionAr;
                subStandardObj.MainStandardId = editSubStandardDTO.MainStandardId;
                _context.SaveChanges();
                return subStandardObj;
            }
            return null;
        }

        public bool DeleteSubStandardById(int id)
        {
            var subStandard = _context.SubStandards.Find(id);
            if (subStandard != null)
            {
                _context.Remove(subStandard);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
