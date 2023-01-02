using AutoMapper;
using FluentValidationApp.DTOs;
using FluentValidationApp.Models;

namespace FluentValidationApp.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Isim, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age))
                .ReverseMap();

            //CreateMap<CustomerDto, Customer>();   ReverseMap() bu işlemi sağlıyor.
        }
    }
}
