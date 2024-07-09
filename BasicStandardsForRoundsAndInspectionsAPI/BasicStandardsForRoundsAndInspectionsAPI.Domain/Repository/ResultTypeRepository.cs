using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultTypeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class ResultTypeRepository: IResultTypeRepository
    {
        public readonly ApplicationDbContext _context;
        public ResultTypeRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<ResultType> GetAllResultTypes()
        {
            return _context.ResultTypes.OrderBy(r=>r.Id); 
        }

        public IndexResultTypeDTO GetResultTypesById(int id)
        {
           var resultType = _context.ResultTypes.Find(id);
            if (resultType != null)
            {
                IndexResultTypeDTO indexResultTypeDTO = new IndexResultTypeDTO()
                {
                    Name = resultType.Name,
                    NameAr = resultType.NameAr
                };
                return indexResultTypeDTO;
            }
            return null;
        }
    }
}
