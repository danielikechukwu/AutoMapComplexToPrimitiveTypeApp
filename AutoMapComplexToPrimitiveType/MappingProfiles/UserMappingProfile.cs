using AutoMapComplexToPrimitiveType.DTOs;
using AutoMapComplexToPrimitiveType.Models;
using AutoMapper;

namespace AutoMapComplexToPrimitiveType.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {

            // Complex -> Primitive (User -> UserDTO)
            // Map the Address object to separate primitive fields
            // Mapping from User (with complex Address) to UserDTO (with primitive address properties)
            // Here, source is the User object and destination is the UserDTO object
             
            CreateMap<User, UserDTO>()
                // For each property in UserDTO that represents an Address field,
                // map it from the corresponding property in the Address complex type.
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

            // Primitive -> Complex (UserCreateDTO -> User)
            // Map separate primitive fields to the complex Address object
            // Mapping from UserCreateDTO (with primitive properties) to User (which contains a complex Address object)
            // Here, source is the UserCreateDTO object and destination is the User object

            CreateMap<UserCreateDTO, User>()
                // When creating a new User, construct the Address object from the primitive properties in UserCreateDTO.
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    City = src.City,
                    State = src.State,
                    ZipCode = src.ZipCode
                }));
        }

    }
}
