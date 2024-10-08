﻿using BasicStandardsForRoundsAndInspectionsAPI.Controllers.Helpers;
using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicStandardsForRoundsAndInspectionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MainStandardController : ControllerBase
    {
        private readonly IMainStandardRepository _mainStandardRepository;

        private readonly ISubStandardRepository _subStandardRepository;
        public MainStandardController(
            IMainStandardRepository mainStandardRepository, 
            ISubStandardRepository subStandardRepository)
        {
            _mainStandardRepository = mainStandardRepository;
            _subStandardRepository = subStandardRepository;
        }

        [HttpGet("GetMainStandards")]
        public IActionResult GetMainStandards()
        {
            var MainStandards = _mainStandardRepository.GetMainStandards();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(MainStandards);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var mainStandard = _mainStandardRepository.GetById(id);
            return Ok(mainStandard);
        }

        [HttpPut]
        [Route("EditById/{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult EditById(int id, EditMainStandardDTO editedMainStandardDTO)
        {
            var editedMainStandard = _mainStandardRepository
                .EditById(id, editedMainStandardDTO);
            return Ok(editedMainStandard);
        }

        [HttpPost("CreateMainStandard")]
        [Authorize(Roles = "Admin")]

        public int CreateMainStandard(CreateMainStandardDTO createMainStandardDTO)
        {
            var newMainStandardId = _mainStandardRepository
                .CreateMainStandard(createMainStandardDTO);
            return newMainStandardId;
        }

        [HttpDelete("DeleteMainStandard/{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteMainStandard(int id)
        {

            var lstSubs = _subStandardRepository
                .GetSubStandardsByMainStandardId(id);
            if (lstSubs.Count() > 0)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response {
                    Status = "sub", 
                    Message = "There are sub Items", 
                    MessageAr = "يوجد بيانات فرعية" 
                });
            }
            else
            {
                var isDeleted = _mainStandardRepository.DeleteById(id);
                if (isDeleted)
                    return Ok(true);
               
            }
             return NotFound(false);

        }

    }
}
