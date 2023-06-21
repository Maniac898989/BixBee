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

       
    }
}
