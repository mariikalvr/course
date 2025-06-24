public record CourseCreateRequest(
    [Required, StringLength(100)] string Title,
    [StringLength(500)] string Description);