using AutoMapper;
using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.ViewModels;

namespace KyhCodeFirstWebApplication.Infrastructure.Profiles;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<Player, PlayerEditViewModel>()
            .ForMember(dest=> dest.Trojnummer, opt=>opt.MapFrom(src=>src.JerseyNumber))
            .ReverseMap();



        CreateMap<Player, PlayerNewViewModel>().ReverseMap();
    }
}