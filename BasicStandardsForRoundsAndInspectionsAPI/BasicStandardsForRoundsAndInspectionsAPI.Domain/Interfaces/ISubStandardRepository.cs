using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces
{
    public interface ISubStandardRepository
    {
        SubStandard CreateSubStandard(CreateSubStandardDTO createSubStandardDTO);
        IEnumerable<SubStandard> GetAllSubStandards();
        IEnumerable<IndexSubStandardDTO> GetSubStandardsByMainStandardId(int mainStandardId);
        IndexSubStandardDTO GetSubStandardById(int id);
        SubStandard EditSubStandardById(int id, EditSubStandardDTO editSubStandardDTO);
        void DeleteSubStandardById(int id);
    }
}
