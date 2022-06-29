using AutoMapper;
using MedicalAPI.DataModels;
using MedicalAPI.DomainModels;
using DataModels = MedicalAPI.DataModels;


namespace MedicalAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataModels.labtests, labtests>()
                .ReverseMap();

            CreateMap<UpdateLabRequest, DataModels.labtests>()
                .ReverseMap();

            CreateMap<AddLabRequest, DataModels.labtests>()
                .ReverseMap();
        }
    }
}
