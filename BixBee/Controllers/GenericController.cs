using BixBee.Domain.Implementation;
using BixBee.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BixBee.Controllers
{
    [SwaggerTag("Generics")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IgenericService _igenericService;

        public GenericController(IgenericService igenericService)
        {
            _igenericService = igenericService ?? throw new ArgumentNullException(nameof(igenericService));
        }

        [HttpGet("get-institution-type")]
        public async Task<IActionResult> GetInstitutionType()
        {
            var states = await _igenericService.GetInstitutionTypes();
            return Ok(states); ;
        }


        [HttpGet("get-institution-category")]
        public async Task<IActionResult> GetInstitutionCategory()
        {
            var states = await _igenericService.GetInstitutionCategory();
            return Ok(states); ;
        }

        [HttpGet("get-all-states")]
        public async Task<IActionResult> GetStates()
        {
            var states = await _igenericService.GetAllStates();
            return Ok(states); ;
        }

        [HttpGet("get-all-lga")]
        public async Task<IActionResult> GetLocalGovernments()
        {
            var lgas = await _igenericService.GetAllLGAs();
            return Ok(lgas); ;
        }

        [HttpGet("get-all-institutions")]
        public async Task<IActionResult> GetAllInstitutions()
        {
            var Institutions = await _igenericService.GetAllInstitutions();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-universities")]
        public async Task<IActionResult> GetAllUniversities()
        {
            var Institutions = await _igenericService.GetAllUniversities();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-polytechnics")]
        public async Task<IActionResult> GetAllPolytec()
        {
            var Institutions = await _igenericService.GetAllPolytechnics();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-federal-universities")]
        public async Task<IActionResult> GetAllFederalUniversities()
        {
            var Institutions = await _igenericService.GetAllFederalUniversities();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-state-universities")]
        public async Task<IActionResult> GetAllStateUniversities()
        {
            var Institutions = await _igenericService.GetAllStateUniversities();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-private-universities")]
        public async Task<IActionResult> GetAllPrivateUniversities()
        {
            var Institutions = await _igenericService.GetAllPrivateUniversities();
            return Ok(Institutions); ;
        }
    }
}
