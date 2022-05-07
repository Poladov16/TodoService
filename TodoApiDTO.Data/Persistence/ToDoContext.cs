using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApiDTO.Data.Entities;

namespace ToDoApiDTO.Data.Persistence
{
    public class ToDoContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ToDoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ToDoContext(DbContextOptions<ToDoContext> options, IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ToDoItem> TodoItems { get; set; }
    }
}
