using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Interfaces;
using PaletYonetimInfrastructure.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;

		public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<UserDto> GetUserByIdAsync(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				// Kullanıcı bulunamazsa null dönebilir veya uygun bir hata fırlatabilirsiniz.
				throw new NotFoundException("Kullanıcı bulunamadı.");
			}

			var userDto = _mapper.Map<UserDto>(user);
			return userDto;
		}

		public async Task<UserDto> RegisterUserAsync(RegisterUserDto registerDto)
		{
			// Yeni ApplicationUser nesnesi oluşturuluyor.
			var user = new ApplicationUser
			{
				UserName = registerDto.Email,
				Email = registerDto.Email,
				FirstName = registerDto.FirstName,
				LastName = registerDto.LastName,
				CreatedTime = DateTime.Now
			};

			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (!result.Succeeded)
			{
				// Hata mesajlarını toplayalım:
				var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
				// Servis katmanında HTTP yanıtı döndürmek yerine hata fırlatmak daha uygundur.
				throw new Exception($"Kullanıcı oluşturulamadı: {errorMessages}");
			}

			return _mapper.Map<UserDto>(user);
		}

		public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
		{
			
			var users = await _userManager.Users.ToListAsync();
			return _mapper.Map<IEnumerable<UserDto>>(users);
		}

		public async Task<UserDto> UpdateUserAsync(string id, UpdateUserDto updateDto)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
				throw new Exception("Kullanıcı bulunamadı.");

			// Güncellenecek alanları ata
			user.FirstName = updateDto.FirstName;
			user.LastName = updateDto.LastName;
			user.Email = updateDto.Email;
			// Gerekirse diğer alanları da güncelleyebilirsiniz.

			var result = await _userManager.UpdateAsync(user);
			if (!result.Succeeded)
			{
				var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
				throw new Exception($"Kullanıcı güncellenemedi: {errorMessages}");
			}

			return _mapper.Map<UserDto>(user);
		}

		public async Task<bool> DeleteUserAsync(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
				throw new Exception("Kullanıcı bulunamadı.");

			var result = await _userManager.DeleteAsync(user);
			if (!result.Succeeded)
			{
				var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
				throw new Exception($"Kullanıcı silinemedi: {errorMessages}");
			}

			return true;
		}
	}
}
