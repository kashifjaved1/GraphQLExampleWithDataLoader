using AutoMapper;
using GraphQLPractice.Data.Entities;
using GraphQLPractice.Models;
using GraphQLPractice.Models.Inputs;

namespace GraphQLPractice.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Gadget, GadgetDTO>().ReverseMap();
            CreateMap<CreateGadgetDTO, GadgetInput>().ReverseMap();
            CreateMap<Gadget, GadgetInput>().ReverseMap();
        }

        
    }
}
