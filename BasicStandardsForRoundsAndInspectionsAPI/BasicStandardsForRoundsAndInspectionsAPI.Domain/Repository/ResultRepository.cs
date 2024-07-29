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
        public IEnumerable<IndexReportDTO> GetReports()
        {
            var reports = _context.Results
                .GroupBy(r => new { r.HospitalId, r.ReportDate })
                .Select(group => new IndexReportDTO
                {
                    HospitalId = group.Key.HospitalId,
                    HospitalName = group.FirstOrDefault().Hospital.Name,
                    HospitalNameAr = group.FirstOrDefault().Hospital.NameAr,
                    ReportDate = group.Key.ReportDate,
                    ReportTakerId = group.FirstOrDefault().ReportTakerId,
                    ReportTakerName = group.FirstOrDefault().ReportTaker != null ? group.FirstOrDefault().ReportTaker.Name : null
                });

            return reports.ToList();
        }

        public IEnumerable<IndexReportDTO> GetResultsByDate(DateTime date)
        {
            return _context.Results.Where(rd => rd.ReportDate == date).ToList().Select(item => new IndexReportDTO
            {
                HospitalId = item.HospitalId,
                ReportDate = item.ReportDate,
                ReportTakerId = item.ReportTakerId,
               
            });
        }

        public IEnumerable<IndexReportDTO> GetResultsByReportTakerId(int employeeId)
        {
            return _context.Results.Where(rd => rd.ReportTakerId == employeeId).ToList().Select(item => new IndexReportDTO
            {
                HospitalId = item.HospitalId,
                ReportDate = item.ReportDate,
                ReportTakerId = item.ReportTakerId,
               
            });
        }

        public IEnumerable<IndexReportDTO> GetResultsByHospitalId(int hospitalId)
        {
            return _context.Results.Where(rd => rd.HospitalId == hospitalId).ToList().Select(item => new IndexReportDTO
            {
                HospitalId = item.HospitalId,
                ReportDate = item.ReportDate,
                ReportTakerId = item.ReportTakerId,
              
            });
        }
        public IEnumerable<Result> CreateResults(IEnumerable<CreateResultDTO> createResultDTOs)
        {
            var resultsToAdd = new List<Result>();
            foreach (var createResultDTO in createResultDTOs)
            {
                var subStandardExists = _context.SubStandards.Any(x => x.Id == createResultDTO.SubstandardId);
                var hospitalExists = _context.Hospitals.Any(x => x.Id == createResultDTO.HospitalId);
                var reportTakerExists = createResultDTO.ReportTakerId.HasValue
                    ? _context.Employees.Any(x => x.Id == createResultDTO.ReportTakerId.Value): true;

                if (hospitalExists && subStandardExists && reportTakerExists)
                {
                    var existingResult = _context.Results
                        .Any(x => x.HospitalId == createResultDTO.HospitalId
                               && x.ReportDate == createResultDTO.ReportDate
                               && x.ReportTakerId == createResultDTO.ReportTakerId
                               && x.SubstandardId == createResultDTO.SubstandardId);

                    if (!existingResult)
                    {
                        var result = new Result
                        {
                            HospitalId = createResultDTO.HospitalId,
                            ReportDate = createResultDTO.ReportDate,
                            ReportTakerId = createResultDTO.ReportTakerId,
                            ResultValue = createResultDTO.ResultValue,
                            SubstandardId = createResultDTO.SubstandardId,
                            Comment = createResultDTO.Comment
                        };

                        resultsToAdd.Add(result);
                    }
                }
            }
            if (resultsToAdd.Any())
            {
                _context.Results.AddRange(resultsToAdd);
                _context.SaveChanges();
            }

            return resultsToAdd;
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
