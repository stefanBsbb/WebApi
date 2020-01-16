using AutoMapper;
using Models;
using Services.CustomModels.Interfaces;
using System;

namespace Services.CustomModels.MapperConfig
{
    public class MapperConfiguratior
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();;
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, User>().ForMember(d => d.ID, opt => opt.MapFrom(x => x.Id));
            CreateMap<User, UserModel>().ForMember(d => d.Id, opt => opt.MapFrom(x => x.ID));

            CreateMap<RegisterModel, User>();
            CreateMap<Role, RoleModel>();

            CreateMap<BookINsModel, BookIn>().ForMember(d => d.RoomID, opt => opt.MapFrom(x => x.Room));
            CreateMap<BookIn, BookINsModel>().ForMember(d => d.Room, opt => opt.MapFrom(x => x.RoomID));

            CreateMap<UserRoles, UserRolesModel>();
            CreateMap<Employee, EmployeeModel>().ForMember(d => d.Id, opt => opt.MapFrom(x => x.ID));
            CreateMap<EmployeeModel, Employee>().ForMember(d => d.ID, opt => opt.MapFrom(x => x.Id));

            CreateMap<Hotel, HotelModel>().ForMember(d => d.Id, opt => opt.MapFrom(x => x.ID));
            CreateMap<HotelModel, Hotel>().ForMember(d => d.ID, opt => opt.MapFrom(x => x.Id));


            CreateMap<Visitor, VisitorModel>();
            CreateMap<Room, RoomModel>();
        }
    }
}
