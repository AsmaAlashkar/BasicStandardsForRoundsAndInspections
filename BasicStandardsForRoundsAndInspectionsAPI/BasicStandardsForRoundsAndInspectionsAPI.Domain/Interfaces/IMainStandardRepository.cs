using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces
{
    public interface IMainStandardRepository
    {
        IEnumerable<MainStandard> GetMainStandards();
        IndexMainStandardDTO GetById(int id);
        MainStandard EditById(int id, EditMainStandardDTO editedMainStandardDTO);
        MainStandard CreateMainStandard (CreateMainStandardDTO create);
        bool DeleteById(int id);
        public bool HasSubStandards(int id);
    }
}
