using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApiDTO.Business.Models.Dto;
using TodoApiDTO.Data.Entities;

namespace TodoApiDTO.Business.Models.MappingProfiles
{
    public class ToDoItemMapperProfile : Profile
    {
        public ToDoItemMapperProfile()
        {
            CreateMap<ToDoItem, ToDoItemDto>().ReverseMap();
        }
    }
}
