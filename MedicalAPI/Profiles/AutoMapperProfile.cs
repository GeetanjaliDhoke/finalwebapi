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
            //Labtests AutoMapper
            CreateMap<DataModels.labtests, labtests>()
                .ReverseMap();

            CreateMap<UpdateLabRequest, DataModels.labtests>()
                .ReverseMap();

            CreateMap<AddLabRequest, DataModels.labtests>()
                .ReverseMap();

            //Radiotests AutoMapper
            CreateMap<DataModels.radiotests, radiotests>()
                .ReverseMap();

            CreateMap<UpdateRadiotestRequest, DataModels.radiotests>()
                .ReverseMap();

            CreateMap<AddRadioRequest, DataModels.radiotests>()
                .ReverseMap();

            //donations
            CreateMap<DataModels.donation, donation>()
                .ReverseMap();

            CreateMap<AddDonationRequest, DataModels.donation>()
                .ReverseMap();
        }
    }
}
