using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Exceptions;
using PaletYonetimApplication.Interfaces;
using System.Threading.Tasks;

namespace PaletYonetimAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		// Eğer servis katmanını kullanmak istemezseniz, UserManager ve IMapper'ı doğrudan da enjekte edebilirsiniz.
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		// Örnek: Belirli bir kullanıcıyı ID ile getirme
		[HttpGet("{id}")]
		/*[Authorize]*/ // Giriş yapmış kullanıcıların erişebilmesi için
		public async Task<IActionResult> GetUser(string id)
		{
			try
			{
				var userDto = await _userService.GetUserByIdAsync(id);
				return Ok(userDto);
			}
			catch (NotFoundException ex)
			{
				// Kullanıcı bulunamadıysa NotFound (404) döndür
				return NotFound(new { Message = ex.Message });
			}
			catch (Exception ex)
			{
				// Diğer hatalar için BadRequest veya InternalServerError dönebilirsiniz
				return BadRequest(new { Message = ex.Message });
			}
		}

		// Örnek: Kullanıcı kayıt işlemi
		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
		{
			try
			{
				var userDto = await _userService.RegisterUserAsync(registerDto);
				return Ok(userDto);
			}
			catch (Exception ex)
			{
				// Hata detaylarını döndürürken dikkatli olun, hassas bilgi vermemeye özen gösterin.
				return BadRequest(new { Message = ex.Message });
			}
		}
		
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetAll()
		{
			var users = await _userService.GetAllUsersAsync();
			return Ok(users);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(string id, [FromBody] UpdateUserDto updateDto)
		{
			try
			{
				var updatedUser = await _userService.UpdateUserAsync(id, updateDto);
				return Ok(updatedUser);
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				await _userService.DeleteUserAsync(id);
				return Ok(new { Message = "Kullanıcı başarıyla silindi." });
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}
	}
}
