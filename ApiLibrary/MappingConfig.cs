using ApiLibrary.Models;
using ApiLibrary.Models.Dto;
using AutoMapper;

namespace ApiLibrary
{
    public class MappingConfig: Profile
    {
        public MappingConfig() 
        {
            CreateMap<Autores, AutoresDto>().ReverseMap();
            CreateMap<Autores, AutoresCreateDto>().ReverseMap();
            CreateMap<Autores, AutoresUpdateDto>().ReverseMap();

            CreateMap<Libros, LibrosDto>().ReverseMap();
            CreateMap<Libros, LibrosCreateDto>().ReverseMap();
            CreateMap<Libros, LibrosUpdateDto>().ReverseMap();  
        }
        
    }
}
