using EffortTracker.Models;
using EffortTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssociatesController : ControllerBase
    {
        private readonly IAssociatesService _associatesService;

        public AssociatesController(IAssociatesService associatesService)
        {
            _associatesService = associatesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Associates>>> GetAll()
        {
            var associates = await _associatesService.GetAllAsync();
            return Ok(associates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Associates>> GetById(int id)
        {
            var associate = await _associatesService.GetByIdAsync(id);
            if (associate == null)
                return NotFound();

            return Ok(associate);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Associates associate)
        {
            await _associatesService.AddAsync(associate);
            return CreatedAtAction(nameof(GetById), new { id = associate.associate_id }, associate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Associates associate)
        {
            if (id != associate.associate_id)
                return BadRequest("ID mismatch");

            await _associatesService.UpdateAsync(associate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _associatesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
