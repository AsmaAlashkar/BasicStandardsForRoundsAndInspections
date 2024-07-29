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
        IEnumerable<IndexReportDTO> GetResultsByHospitalId(int hospitalId);
        IEnumerable<IndexReportDTO> GetResultsByReportTakerId(int employeeId);
        IEnumerable<IndexReportDTO> GetResultsByDate(DateTime date);
        IEnumerable<Result> CreateResults(IEnumerable<CreateResultDTO> createResultDTOs);
        Result EditResult(EditResultDTO editedResultDTO);
        bool DeleteResult(DeleteResultDTO deletedResultDTO);

    }
}
