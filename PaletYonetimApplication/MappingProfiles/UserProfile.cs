using AutoMapper;
using PaletYonetimApplication.DTO;
using PaletYonetimApplication.Interfaces;

namespace PaletYonetimApplication.MappingProfiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<IApplicationUser, UserDto>();
		}
	}
}
