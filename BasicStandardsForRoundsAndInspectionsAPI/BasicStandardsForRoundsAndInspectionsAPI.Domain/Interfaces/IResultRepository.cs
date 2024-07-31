using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces
{
    public interface IResultRepository
    {
        IEnumerable<IndexReportDTO> GetReports();
        IEnumerable<IndexResultsOfReportDTO> GetResultsOfReport(int hospitalId, DateTime reportDate);

        IEnumerable<Result> CreateResults(IEnumerable<CreateResultDTO> createResultDTOs);
        IEnumerable<Result> EditResults(IEnumerable<EditResultDTO> editedResultDTOs);
        bool DeleteResults(int hospitalId, DateTime reportDate);
        //IEnumerable<IndexReportDTO> GetResultsByHospitalId(int hospitalId);
        //IEnumerable<IndexReportDTO> GetResultsByReportTakerId(int employeeId);
        //IEnumerable<IndexReportDTO> GetResultsByDate(DateTime date);
    }
}
