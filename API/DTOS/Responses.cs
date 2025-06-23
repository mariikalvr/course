// AuthResponse.cs
public record AuthResponse(int Id, string Email, string Role);

// CourseResponse.cs
public record CourseResponse(
    int Id,
    string Title,
    string Description,
    string TeacherName);