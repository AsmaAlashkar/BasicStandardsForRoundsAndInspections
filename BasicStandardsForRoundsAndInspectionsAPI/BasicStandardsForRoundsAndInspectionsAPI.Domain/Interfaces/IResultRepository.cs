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
        IEnumerable<IndexResultDTO> GetResults();
        IEnumerable<IndexResultDTO> GetResultsByHospitalId(int hospitalId);
        IEnumerable<IndexResultDTO> GetResultsByReportTakerId(int employeeId);
        IEnumerable<IndexResultDTO> GetResultsByDate(DateTime date);
        Result CreateResult(CreateResultDTO createResultDTO);
        Result EditResult(EditResultDTO editedResultDTO);
        bool DeleteResult(DeleteResultDTO deletedResultDTO);

    }
}
