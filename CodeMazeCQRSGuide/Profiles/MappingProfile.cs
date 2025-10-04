using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace CodeMazeCQRSGuide.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ReverseMap();

        CreateMap<CompanyForCreationDto, Company>();
    }
}
