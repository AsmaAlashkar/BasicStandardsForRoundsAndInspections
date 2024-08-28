using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.reportTakerEmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces
{
    public interface IReportTakerEmployeeRepository
    {
        IEnumerable<IndexreportTakerEmployeeDTO> GetReportTakersNames();
        IndexreportTakerEmployeeDTO GetReportTakerNameById(int id);
    }
}
