using GenericBack.Application.DTOs;
using GenericBack.Domain.Entities;
using AutoMapper;
using GenericBack.Domain.Interfaces;
using GenericBack.Application.Interfaces;

namespace GenericBack.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user is null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            await _repository.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateAsync(Guid id, CreateUserDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("User not found.");

            existing.Name = dto.Name;
            existing.Email = dto.Email;
            if (!string.IsNullOrWhiteSpace(dto.Password))
                existing.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
