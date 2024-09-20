using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VolunteerVision.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class ApiController : ControllerBase
{
    [HttpGet]
    [Route("volunteerprojects")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var volunteerProjects = await context
            .VolunteerProjects
            .AsNoTracking()
            .ToListAsync();
        return Ok(volunteerProjects);
    }

    [HttpGet]
    [Route("volunteerprojects/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var volunteerProject = await context
            .VolunteerProjects
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return volunteerProject == null ? NotFound() : Ok(volunteerProject);
    }

    // [HttpPost]
    // [Route("volunteerprojects")]
    // public async Task<IActionResult> PostAsync(
    //     [FromServices] AppDbContext context,
    //     VolunteerProject volunteerProject)
    // {

    // }
}

