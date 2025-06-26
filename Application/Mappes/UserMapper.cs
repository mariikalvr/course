using API.DTOs.Auth;
using projects.Domain.Entities;

namespace Application.Mappers;

public static class UserMapper
{
    public static UserProfileDto ToUserProfileDto(this User user)
    {
        return new UserProfileDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = user.Role.ToString()
        };
    }
}