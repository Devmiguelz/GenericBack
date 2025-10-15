using GenericBack.Application.DTOs;

namespace GenericBack.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task UpdateAsync(Guid id, CreateUserDto dto);
        Task DeleteAsync(Guid id);
    }
}
