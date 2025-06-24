// public class AttendanceService : IAttendanceService
// {
//     public Task<IEnumerable<AttendanceDto>> GetByLesson(int lessonId)
//     {
//         // Реализация получения данных
//         return Task.FromResult<IEnumerable<AttendanceDto>>(new List<AttendanceDto>
//         {
//             new(1, "John Doe", true),
//             new(2, "Jane Smith", false)
//         });
//     }

//     public Task<string> MarkAttendance(int lessonId, List<AttendanceMarkRequest> request)
//     {
//         // Реализация сохранения отметок
//         return Task.FromResult($"Attendance for lesson {lessonId} marked successfully");
//     }
// }