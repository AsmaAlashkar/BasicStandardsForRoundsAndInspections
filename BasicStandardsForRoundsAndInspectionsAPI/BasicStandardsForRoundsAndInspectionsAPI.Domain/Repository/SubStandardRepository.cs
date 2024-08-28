using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
//using Microsoft.AspNetCore.Hosting;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class SubStandardRepository : ISubStandardRepository
    {
        private readonly ApplicationDbContext _context;
        //IWebHostEnvironment _webHostingEnvironment;

        public SubStandardRepository(ApplicationDbContext context)//, IWebHostEnvironment webHostingEnvironment
        {
            _context = context;
            //_webHostingEnvironment = webHostingEnvironment;

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
                    MainStandardId = createSubStandardDTO.MainStandardId,
                    ResultTypeId = createSubStandardDTO.ResultTypeId
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
                    MainStandardId = subStandard.MainStandardId,
                    ResultTypeId = subStandard.ResultTypeId
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
                Id = item.Id,
                Description= item.Description,
                DescriptionAr= item.DescriptionAr,
                Code= item.Code,
                MainStandardId = item.MainStandardId,
                ResultTypeId = item.ResultTypeId
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
                subStandardObj.ResultTypeId = editSubStandardDTO.ResultTypeId;
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
