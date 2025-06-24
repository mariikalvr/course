public interface ICourseService
{
    Task<IEnumerable<CourseResponse>> GetAllAsync();
    Task<CourseResponse> GetByIdAsync(int id);
    Task<CourseResponse> CreateAsync(CourseCreateRequest request);
}