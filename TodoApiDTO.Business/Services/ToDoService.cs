using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApiDTO.Business.Models.Dto;
using TodoApiDTO.Data.Entities;
using TodoApiDTO.Data.Persistence;

namespace TodoApiDTO.Business.Services
{
    public class ToDoService : ITodoService
    {
        private readonly ToDoContext _todoService;
        private readonly IMapper _mapper;
        public ToDoService(ToDoContext todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }
        public async Task<ToDoItemDto> AddAsync(ToDoItemDto todoItemDTO)
        {
            var todoItemEntity = _mapper.Map<ToDoItem>(todoItemDTO);
            await _todoService.TodoItems.AddAsync(todoItemEntity);
            var result = await _todoService.SaveChangesAsync();

            if (result == 0)
            {
                throw new Exception("Couldn't save the entity.");
            }

            return todoItemDTO;
        }

        public async Task<int> DeleteAsync(long id)
        {
            var todoItemEntity = await _todoService.TodoItems.FirstOrDefaultAsync(f => f.Id == id);

            if (todoItemEntity != null)
            {
                _todoService.TodoItems.Remove(todoItemEntity);
                var result = await _todoService.SaveChangesAsync();
                return result;

            }

            return 0;
        }

        public async Task<List<ToDoItemDto>> GetAllAsync()
        {
            var todoItems = await _todoService.TodoItems.ToListAsync();
            var todoItemEntity = _mapper.Map<List<ToDoItemDto>>(todoItems);
            return todoItemEntity;
        }

        public async Task<ToDoItemDto> GetAsync(long id)
        {
            var todoItems = await _todoService.TodoItems.FirstOrDefaultAsync(f => f.Id == id);
            var todoItemEntity = _mapper.Map<ToDoItemDto>(todoItems);
            return todoItemEntity;
        }

        public async Task<int> UpdateAsync(long id, ToDoItemDto todoItemDTO)
        {
            var todoItemEntity = await _todoService.TodoItems.FirstOrDefaultAsync(f => f.Id == id);

            if (todoItemEntity == null)
            {
                throw new Exception("Not Found");
            }
            _todoService.TodoItems.Update(todoItemEntity);
            var result = await _todoService.SaveChangesAsync();
            return result;
        }

    }
}
