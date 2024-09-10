using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SettingDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingRepository _settingRepository;

        string strLogo, strLogoTitle, strLogoTitleAr = "";

        public SettingController( ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }


        [HttpGet]
        [Route("GetSettings")]
        public IEnumerable<IndexSettingDTO> GetSettings()
        {
            var lstsettings = _settingRepository.GetAll().ToList();
            if (lstsettings.Count > 0)
            {
                foreach (var item in lstsettings)
                {
                   
                        strLogo = item.Logo;
                   
                        strLogoTitle = item.LogoTitle;
                    strLogoTitleAr = item.LogoTitleAr;


                }
            }
            return lstsettings;
        }


    }
}
