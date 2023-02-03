using Kolokwium.DTO;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDbService _dbService;

        public ProjectController(IDbService dbService)
        {
            _dbService = dbService;
        }

            [HttpGet]
        public async Task<IActionResult> GetProjects(int idProject)
        {

            try
            {
                ICollection<ProjectDTO> p = await _dbService.GetProjects(idProject);
                if (p == null)
                {
                    return NotFound();
                }
                return Ok(p);
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);               
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddtaskAsync(TaskREQDTO request)
        {
            try
            {
                return Ok(await _dbService.CreateTaskAsync(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
