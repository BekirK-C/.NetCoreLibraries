using AutoMapper;
using FluentValidationApp.DTOs;
using FluentValidationApp.Models;

namespace FluentValidationApp.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            //CreateMap<CustomerDto, Customer>();   ReverseMap() bu işlemi sağlıyor.
        }
    }
}
