using EffortTracker.Models;
using EffortTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsService _service;

        public ApplicationsController(IApplicationsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applications>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Applications>> GetById(int id)
        {
            var app = await _service.GetByIdAsync(id);
            if (app == null) return NotFound();
            return Ok(app);
        }

        [HttpPost]
        public async Task<ActionResult<Applications>> Create(Applications application)
        {
            var created = await _service.AddAsync(application);
            return CreatedAtAction(nameof(GetById), new { id = created.application_id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Applications>> Update(int id, Applications application)
        {
            if (id != application.application_id) return BadRequest();
            return Ok(await _service.UpdateAsync(application));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
