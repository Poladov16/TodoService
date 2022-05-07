using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApiDTO.Data.Entities;

namespace ToDoApiDTO.Business.Models.MappingProfiles
{
    public class ToDoItemMapperProfile : Profile
    {
        public ToDoItemMapperProfile()
        {
            CreateMap<ToDoItem, ToDoItemDto>().ReverseMap();
        }
    }
}
