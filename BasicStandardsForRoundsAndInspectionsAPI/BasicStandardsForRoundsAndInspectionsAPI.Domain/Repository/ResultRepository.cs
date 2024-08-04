using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<IndexResultsOfReportDTO> GetResultsOfReport(int hospitalId, DateTime reportDate)
        {
            var results = _context.Results
                .Where(r => r.HospitalId == hospitalId && r.ReportDate == reportDate)
                .Include(r => r.Hospital)
                .Include(r => r.ReportTaker)
                .Include(r => r.SubStandard)
                .ThenInclude(s => s.MainStandard)
                .ToList();

            var groupedResults = results
                .GroupBy(r => new { r.HospitalId, r.ReportDate, r.ReportTakerId, ReportTakerName = r.ReportTaker?.Name })
                .Select(g => new IndexResultsOfReportDTO
                {
                    HospitalId = g.Key.HospitalId,
                    HospitalName = g.First().Hospital?.Name,
                    HospitalNameAr = g.First().Hospital?.NameAr,
                    ReportDate = g.Key.ReportDate,
                    ReportTakerId = g.Key.ReportTakerId,
                    ReportTakerName = g.Key.ReportTakerName,
                    MainStandards = g
                        .GroupBy(r => r.SubStandard.MainStandardId)
                        .Select(mg => new MainStandardResultDTO
                        {
                            Title = mg.First().SubStandard.MainStandard.Title,
                            TitleAr = mg.First().SubStandard.MainStandard.TitleAr,
                            Substandards = mg
                                .Select(r => new SubstandardResultDTO
                                {
                                    Description = r.SubStandard.Description,
                                    DescriptionAr = r.SubStandard.DescriptionAr,
                                    ResultValue = r.ResultValue,
                                    Comment = r.Comment,
                                    ResultTypeId = r.SubStandard.ResultTypeId  
                                }).ToList()
                        }).ToList()
                }).ToList();

            return groupedResults;
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

        public IEnumerable<Result> EditResults(IEnumerable<EditResultDTO> editedResultDTOs)
        {
            var resultsToEdit = new List<Result>();

            foreach (var editResultDTO in editedResultDTOs)
            {
                var existingResult = _context.Results
                    .FirstOrDefault(x => x.HospitalId == editResultDTO.HospitalId
                                      && x.ReportDate.Date == editResultDTO.ReportDate.Date
                                      && x.SubstandardId == editResultDTO.SubstandardId);

                if (existingResult != null)
                {
                    existingResult.ResultValue = editResultDTO.ResultValue;
                    existingResult.Comment = editResultDTO.Comment;

                    resultsToEdit.Add(existingResult);
                }
            }

            if (resultsToEdit.Any())
            {
                _context.Results.UpdateRange(resultsToEdit);
                _context.SaveChanges();
            }

            return resultsToEdit;
        }

        public bool DeleteResults(int hospitalId, DateTime reportDate)
        {
            var resultsToDelete = _context.Results
                            .Where(x => x.HospitalId == hospitalId && x.ReportDate.Date == reportDate.Date)
                            .ToList();
            if (resultsToDelete.Any())
            {
                _context.Results.RemoveRange(resultsToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        //public IEnumerable<IndexReportDTO> GetResultsByDate(DateTime date)
        //{
        //    return _context.Results.Where(rd => rd.ReportDate == date).ToList().Select(item => new IndexReportDTO
        //    {
        //        HospitalId = item.HospitalId,
        //        ReportDate = item.ReportDate,
        //        ReportTakerId = item.ReportTakerId,

        //    });
        //}

        //public IEnumerable<IndexReportDTO> GetResultsByReportTakerId(int employeeId)
        //{
        //    return _context.Results.Where(rd => rd.ReportTakerId == employeeId).ToList().Select(item => new IndexReportDTO
        //    {
        //        HospitalId = item.HospitalId,
        //        ReportDate = item.ReportDate,
        //        ReportTakerId = item.ReportTakerId,

        //    });
        //}

        //public IEnumerable<IndexReportDTO> GetResultsByHospitalId(int hospitalId)
        //{
        //    return _context.Results.Where(rd => rd.HospitalId == hospitalId).ToList().Select(item => new IndexReportDTO
        //    {
        //        HospitalId = item.HospitalId,
        //        ReportDate = item.ReportDate,
        //        ReportTakerId = item.ReportTakerId,

        //    });
        //}

    }
}
