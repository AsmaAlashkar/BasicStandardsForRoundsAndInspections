using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO;
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

        public IEnumerable<IndexResultDTO> GetResults()
        {

            var results = from result in _context.Results
                          join hospital in _context.Hospitals on result.HospitalId equals hospital.Id
                          join employee in _context.Employees on result.ReportTakerId equals employee.Id
                          join substandard in _context.SubStandards on result.SubstandardId equals substandard.Id
                          join mainStandard in _context.MainStandards on substandard.MainStandardId equals mainStandard.Id
                          select new IndexResultDTO
                          {
                              HospitalId = result.HospitalId,
                              HospitalName = hospital.Name,
                              HospitalNameAr = hospital.NameAr,
                              ReportDate = result.ReportDate,
                              ReportTakerId = result.ReportTakerId,
                              ReportTakerName = employee.Name,
                              SubstandardId = result.SubstandardId,
                              SubstandardName = substandard.Description,
                              SubstandardNameAr = substandard.DescriptionAr,
                              ResultValue = result.ResultValue,
                              MainStandardId = mainStandard.Id,
                              MainStandardName = mainStandard.Title,
                              MainStandardNameAr = mainStandard.TitleAr
                          };


            return results.ToList();
        }

        public IEnumerable<IndexResultDTO> GetResultsByDate(DateTime date)
        {
            return _context.Results.Where(rd => rd.ReportDate == date).ToList().Select(item => new IndexResultDTO
            {
                HospitalId = item.HospitalId,
                ReportDate = item.ReportDate,
                ReportTakerId = item.ReportTakerId,
                SubstandardId = item.SubstandardId,
                ResultValue = item.ResultValue,
                Comment= item.Comment
            });
        }

        public IEnumerable<IndexResultDTO> GetResultsByReportTakerId(int employeeId)
        {
            return _context.Results.Where(rd => rd.ReportTakerId == employeeId).ToList().Select(item => new IndexResultDTO
            {
                HospitalId = item.HospitalId,
                ReportDate = item.ReportDate,
                ReportTakerId = item.ReportTakerId,
                SubstandardId = item.SubstandardId,
                ResultValue = item.ResultValue,
                Comment = item.Comment
            });
        }

        public IEnumerable<IndexResultDTO> GetResultsByHospitalId(int hospitalId)
        {
            return _context.Results.Where(rd => rd.HospitalId == hospitalId).ToList().Select(item => new IndexResultDTO
            {
                HospitalId = item.HospitalId,
                ReportDate = item.ReportDate,
                ReportTakerId = item.ReportTakerId,
                SubstandardId = item.SubstandardId,
                ResultValue = item.ResultValue,
                Comment = item.Comment
            });
        }

        public Result CreateResult(CreateResultDTO createResultDTO)
        {
            var subStandardExists = _context.SubStandards.Any(x => x.Id == createResultDTO.SubstandardId);
            var hospitalExists = _context.Hospitals.Any(x => x.Id == createResultDTO.HospitalId);
            var reportTakerExists = _context.Employees.Any(x => x.Id == createResultDTO.ReportTakerId);

            if (hospitalExists && reportTakerExists && subStandardExists)
            {
                var existingResult = _context.Results.FirstOrDefault(x => x.SubstandardId == createResultDTO.SubstandardId);
                if (existingResult == null)
                {
                    var result = new Result
                    {
                        HospitalId = createResultDTO.HospitalId,
                        ReportDate = createResultDTO.ReportDate,
                        ReportTakerId = createResultDTO.ReportTakerId,
                        ResultValue = createResultDTO.ResultValue,
                        SubstandardId=createResultDTO.SubstandardId,
                        Comment = createResultDTO.Comment
                    };
                    _context.Results.Add(result);
                    _context.SaveChanges();
                    return result;
                }
            }
            return null;
        }


        public Result EditResult(EditResultDTO editedResultDTO)
        {
            var result = _context.Results.FirstOrDefault(x =>
            x.HospitalId == editedResultDTO.HospitalId &&
            x.ReportDate == editedResultDTO.ReportDate &&
            x.SubstandardId == editedResultDTO.SubstandardId);

            if (result == null)
            {
                throw new KeyNotFoundException("Result not found.");
            }

            result.ResultValue = editedResultDTO.ResultValue;
            result.Comment = editedResultDTO.Comment;

            _context.SaveChanges();
            return result;
        }

        public bool DeleteResult(DeleteResultDTO deletedResultDTO)
        {
            var result = _context.Results.FirstOrDefault(x =>
            x.HospitalId == deletedResultDTO.HospitalId &&
            x.ReportDate == deletedResultDTO.ReportDate &&
            x.SubstandardId == deletedResultDTO.SubstandardId);

            if (result == null)
            {
                return false;
            }

            _context.Results.Remove(result);
            _context.SaveChanges();
            return true;
        }

        }
}
