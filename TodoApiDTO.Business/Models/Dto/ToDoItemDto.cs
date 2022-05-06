using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApiDTO.Business.Models.Dto
{

    #region snippet
    public class ToDoItemDto
    {
        public ToDoItemDto()
        {
        }

        public ToDoItemDto(int id, string name, bool isComplete)
        {

            Id = id;
            Name = name;
            IsComplete = isComplete;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
    #endregion
}
