using PaletYonetimApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletYonetimApplication.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> GetUserByIdAsync(string id);
		Task<UserDto> RegisterUserAsync(RegisterUserDto registerDto);
		Task<IEnumerable<UserDto>> GetAllUsersAsync();
		Task<UserDto> UpdateUserAsync(string id, UpdateUserDto updateDto);
		Task<bool> DeleteUserAsync(string id);
		// Giriş, şifre sıfırlama gibi diğer metotlar da eklenebilir.
	}
}
