﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApiDTO.Business.Models.Dto;

namespace TodoApiDTO.Business.Services
{
    public interface ITodoService
    {
        Task<int> UpdateAsync(long id, ToDoItemDto todoItemDTO);

        Task<ToDoItemDto> AddAsync(ToDoItemDto todoItemDTO);

        Task<int> DeleteAsync(long id);

        Task<List<ToDoItemDto>> GetAllAsync();

        Task<ToDoItemDto> GetAsync(long id);


    }
}
