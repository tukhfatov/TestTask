using AutoMapper;

namespace Application.Automapper
{
    public class DtoToDomainMappingProfile: Profile
    {
        public DtoToDomainMappingProfile()
        {
//            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
 //               .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
//            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
//                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}