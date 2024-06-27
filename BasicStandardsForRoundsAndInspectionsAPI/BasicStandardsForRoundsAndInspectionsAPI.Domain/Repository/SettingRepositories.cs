
using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SettingDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class SettingRepositories : ISettingRepository
    {
        private ApplicationDbContext _context;

        public SettingRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
    

        public IEnumerable<IndexSettingDTO> GetAll()
        {
            List<IndexSettingDTO> list = new List<IndexSettingDTO>();
            var lstsettings = _context.Settings.ToList();
            if (lstsettings.Count > 0)
            {
                foreach (var item in lstsettings)
                {
                    IndexSettingDTO indexSetting = new IndexSettingDTO();

                    if (item.KeyName == "Logo")
                    {
                        indexSetting.Logo = item.KeyValue;
                    }
                    if (item.KeyName == "LogoTitle")
                    {
                        indexSetting.LogoTitle = item.KeyValue;
                    }
                    if (item.KeyName == "LogoTitle")
                    {
                        indexSetting.LogoTitleAr = item.KeyValueAr;
                    }

                    list.Add(indexSetting);
                }
            }
            return list;
        }

    }
}
