public record AttendanceMarkRequest(int StudentId, bool IsPresent);
public record AttendanceDto(int StudentId, string StudentName, bool IsPresent);

public interface IAttendanceService
{
    Task<IEnumerable<AttendanceDto>> GetByLesson(int lessonId);
    Task<string> MarkAttendance(int lessonId, List<AttendanceMarkRequest> request);
}