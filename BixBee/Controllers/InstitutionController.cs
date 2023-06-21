using BixBee.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BixBee.Controllers
{
    [SwaggerTag("Institutions")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IinstitutionService _iinstitutionService;

        public InstitutionController(IinstitutionService iinstitutionServic)
        {
            _iinstitutionService = iinstitutionServic ?? throw new ArgumentNullException(nameof(_iinstitutionService));
        }

        [HttpGet("get-all-institutions")]
        public async Task<IActionResult> GetAllInstitutions()
        {
            var Institutions = await _iinstitutionService.GetAllInstitutions();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-universities")]
        public async Task<IActionResult> GetAllUniversities()
        {
            var Institutions = await _iinstitutionService.GetAllUniversities();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-polytechnics")]
        public async Task<IActionResult> GetAllPolytec()
        {
            var Institutions = await _iinstitutionService.GetAllPolytechnics();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-federal-universities")]
        public async Task<IActionResult> GetAllFederalUniversities()
        {
            var Institutions = await _iinstitutionService.GetAllFederalUniversities();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-state-universities")]
        public async Task<IActionResult> GetAllStateUniversities()
        {
            var Institutions = await _iinstitutionService.GetAllStateUniversities();
            return Ok(Institutions); ;
        }

        [HttpGet("get-all-private-universities")]
        public async Task<IActionResult> GetAllPrivateUniversities()
        {
            var Institutions = await _iinstitutionService.GetAllPrivateUniversities();
            return Ok(Institutions); ;
        }

    }
}
