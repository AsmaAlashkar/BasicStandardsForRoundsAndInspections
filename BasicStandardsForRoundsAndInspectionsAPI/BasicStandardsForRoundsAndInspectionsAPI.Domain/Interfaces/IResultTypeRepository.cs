using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.ResultTypeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces
{
    public interface IResultTypeRepository
    {
        IEnumerable<ResultType> GetAllResultTypes();
        IndexResultTypeDTO GetResultTypesById(int id);
    }
}
