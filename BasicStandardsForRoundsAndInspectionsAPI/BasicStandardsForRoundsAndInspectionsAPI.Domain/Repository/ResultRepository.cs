using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly ApplicationDbContext _context;
        public ResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Result> GetResults()
        {
            return _context.Results.OrderBy(m => m.Id);
        }
        public IndexResultDTO GetResultById(int id)
        {
            var result = _context.Results.Find(id);
            if (result != null)
            {
                IndexResultDTO dto = new IndexResultDTO
                {
                    ResultValue = result.ResultValue,
                    ResultValueAr = result.ResultValueAr
                };
                return dto;
            }
            return null;
        }
        public IEnumerable<IndexResultDTO> GetResultBySubStandardId(int subStandardId)
        {
            return _context.Results.Where(s => s.SubStandardId == subStandardId).ToList().Select(item => new IndexResultDTO
            {
                ResultValue = item.ResultValue,
                ResultValueAr = item.ResultValueAr,
                SubStandardId=item.SubStandardId,
                ResultTypeId = item.ResultTypeId
            });
        }
        public Result CreateOrUpdateResult(CreateResultDTO createResultDTO)
        {
            var subStandardExists = _context.SubStandards.Any(x => x.Id == createResultDTO.SubStandardId);
            if (subStandardExists)
            {
                var existingResult = _context.Results.FirstOrDefault(x => x.SubStandardId == createResultDTO.SubStandardId);
                if (existingResult != null)
                {
                    // Update existing result
                    existingResult.ResultValue = createResultDTO.ResultValue;
                    existingResult.ResultValueAr = createResultDTO.ResultValueAr;
                    _context.SaveChanges();
                    return existingResult;
                }
                else
                {
                    // Create new result
                    var result = new Result
                    {
                        ResultValue = createResultDTO.ResultValue,
                        ResultValueAr = createResultDTO.ResultValueAr,
                        ResultTypeId = createResultDTO.ResultTypeId,
                        SubStandardId = createResultDTO.SubStandardId
                    };
                    _context.Add(result);
                    _context.SaveChanges();
                    return result;
                }
            }
            return null;
        }


        //public Result CreateResult(CreateResultDTO createResultDTO)
        //{
        //    var subStandardExists = _context.SubStandards.Any(x => x.Id == createResultDTO.SubStandardId);
        //    if (subStandardExists)
        //    {
        //        var existingResult = _context.Results.FirstOrDefault(x => x.SubStandardId == createResultDTO.SubStandardId);
        //        if (existingResult == null)
        //        {
        //            var result = new Result
        //            {
        //                ResultValue = createResultDTO.ResultValue,
        //                ResultValueAr = createResultDTO.ResultValueAr,
        //                ResultTypeId = createResultDTO.ResultTypeId,
        //                SubStandardId = createResultDTO.SubStandardId
        //            };
        //            _context.Add(result);
        //            _context.SaveChanges();
        //            return result;
        //        }
        //    }
        //    return null;
        //}
        //public Result EditResultById(int id, EditResultDTO editedResultDTO)
        //{
        //    var resultObj = _context.Results.Find(editedResultDTO.Id);
        //    if (resultObj != null)
        //    {
        //        resultObj.ResultValue = editedResultDTO.ResultValue;
        //        resultObj.ResultValueAr = editedResultDTO.ResultValueAr;
        //        _context.SaveChanges();
        //        return resultObj;
        //    }
        //    return null;
        //}
        public bool DeleteResultById(int id)
        {
            var result = _context.Results.Find(id);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
