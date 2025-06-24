using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/groups")]
[Authorize]
public class GroupsController : ControllerBase
{
    private readonly IGroupService _groupService;

    [HttpGet]
    public IActionResult GetAll([FromQuery] int? courseId)
    {
        var groups = _groupService.GetAll(courseId);
        return Ok(groups);
    }

  
}