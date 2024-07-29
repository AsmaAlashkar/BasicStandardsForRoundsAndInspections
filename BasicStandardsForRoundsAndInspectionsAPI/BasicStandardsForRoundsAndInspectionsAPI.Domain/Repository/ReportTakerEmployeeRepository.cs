using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.HospitalDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.reportTakerEmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class ReportTakerEmployeeRepository:IReportTakerEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportTakerEmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IndexreportTakerEmployeeDTO> GetReportTakersNames()
        {
            return _context.Employees.Select(i => new IndexreportTakerEmployeeDTO
            {
                Id = i.Id,
                Name = i.Name
            }).ToList();
        }
    }
}
