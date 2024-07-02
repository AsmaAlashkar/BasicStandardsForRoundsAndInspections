using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class MainStandardRepository : IMainStandardRepository
    {
        private readonly ApplicationDbContext _context;
        public MainStandardRepository(ApplicationDbContext context)
        {
            _context = context;   
        }
        public IEnumerable<MainStandard> GetMainStandards()
        {
            return _context.MainStandards.OrderBy(m => m.Id);
        }
        public IndexMainStandardDTO GetById(int id)
        {
            var mainStandard = _context.MainStandards.Find(id);
            if (mainStandard != null)
            {
                IndexMainStandardDTO dto = new IndexMainStandardDTO
                {
                    Title = mainStandard.Title,
                    TitleAr = mainStandard.TitleAr
                };
                return dto;
            }
            return null;
        }
        public MainStandard EditById(int id, EditMainStandardDTO editedMainStandardDTO)
        {
            var mainStandardObj = _context.MainStandards.Find(editedMainStandardDTO.Id);
            if (mainStandardObj != null)
            {
                mainStandardObj.Title = editedMainStandardDTO.Title;
                mainStandardObj.TitleAr = editedMainStandardDTO.TitleAr;
                _context.SaveChanges();
                return mainStandardObj;
            }
            return null;
        }


        public MainStandard CreateMainStandard(CreateMainStandardDTO create)
        {
            var newMainStandard = new MainStandard
            {
                Title = create.Title,
                TitleAr = create.TitleAr
            };
            _context.Add(newMainStandard);
            _context.SaveChanges();
            return newMainStandard;
        }

        public bool DeleteById(int id)
        {
            var mainStandard = _context.MainStandards.Find(id);

            if (mainStandard != null && !HasSubStandards(id)) 
            {
                    _context.Remove(mainStandard);
                    _context.SaveChanges();
                    return true;
            }
          
            return false;

        }
        public bool HasSubStandards(int id)
        {
            return _context.SubStandards.Any(s=>s.MainStandardId == id);
        }
       
    }
}
