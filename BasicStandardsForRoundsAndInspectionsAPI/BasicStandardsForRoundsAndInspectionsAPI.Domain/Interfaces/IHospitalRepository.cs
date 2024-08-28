using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.HospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces
{
    public interface IHospitalRepository
    {
        IEnumerable<IndexHospitalDTO> GetAllHospitalsNames();
        IndexHospitalDTO getHospitalNameById(int id);
    }
}
