// using FluentValidation;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// [ApiController]
// [Route("api/courses")]
// [Authorize]
// public class CoursesController : ControllerBase
// {
//     private readonly ICourseService _courseService;
//     private readonly IValidator<CourseCreateRequest> _validator;

//     public CoursesController(
//         ICourseService courseService,
//         IValidator<CourseCreateRequest> validator)
//     {
//         _courseService = courseService;
//         _validator = validator;
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetAll()
//     {
//         var courses = await _courseService.GetAllAsync();
//         return Ok(courses);
//     }

//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetById(int id)
//     {
//         try
//         {
//             var course = await _courseService.GetByIdAsync(id);
//             return Ok(course);
//         }
//         catch (DllNotFoundException ex)
//         {
//             return NotFound(new { error = ex.Message });
//         }
//     }

//     [HttpPost]
//     [Authorize(Roles = "Teacher")]
//     public async Task<IActionResult> Create(CourseCreateRequest request)
//     {
//         var validationResult = await _validator.ValidateAsync(request);
//         if (!validationResult.IsValid)
//         {
//             return BadRequest(validationResult.Errors);
//         }

//         try
//         {
//             var course = await _courseService.CreateAsync(request);
//             return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
//         }
//         catch (BadRequestException ex)
//         {
//             return BadRequest(new { error = ex.Message });
//         }
//     }
// }