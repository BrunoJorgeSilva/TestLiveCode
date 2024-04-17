using TestLiveCode.Model;
using TestLiveCode.ViewModel;
using AutoMapper;

namespace TestLiveCode.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<Ticket, TicketViewModel>();
            CreateMap<UserLogin, UserLoginViewModel>();

            CreateMap<ClientViewModel, Client>();
            CreateMap<TicketViewModel, Ticket>();
            CreateMap< UserLoginViewModel, UserLogin>();
        }
    }
}
