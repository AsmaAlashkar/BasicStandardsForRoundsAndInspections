using BasicStandardsForRoundsAndInspectionsAPI.Models;
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
        IEnumerable<Result> GetResults();
        IndexResultDTO GetResultById(int id);
        IEnumerable<IndexResultDTO> GetResultBySubStandardId(int subStandardId);
        Result CreateOrUpdateResult(CreateResultDTO createResultDTO);
        //Result EditResultById(int id, EditResultDTO editedResultDTO);
        //Result CreateResult(CreateResultDTO createResultDTO);
        bool DeleteResultById(int id);
    }
}
