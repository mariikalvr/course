// using FluentValidation;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("api/lessons/{lessonId}/attendance")]
// [Authorize]
// public class AttendanceController : ControllerBase
// {
//     private readonly IAttendanceService _attendanceService;

//     public AttendanceController(IAttendanceService attendanceService)
//     {
//         _attendanceService = attendanceService;
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetByLesson(int lessonId)
//     {
//         var attendance = await _attendanceService.GetByLesson(lessonId);
//         return Ok(attendance);
//     }

//     [HttpPost]
//     [Authorize(Roles = "Teacher")]
//     public async Task<IActionResult> MarkAttendance(
//         int lessonId, 
//         [FromBody] List<AttendanceMarkRequest> request)
//     {
//         var result = await _attendanceService.MarkAttendance(lessonId, request);
//         return Ok(result);
//     }
// }