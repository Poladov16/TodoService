using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ToDoApiDTO.Business.Services;
using ToDoApiDTO.Data.Persistence;

namespace ToDoProject.Business
{
    public static class Startup
    {
        public static void Initialize(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.Load("TodoProject.Business"));
            serviceCollection.AddScoped<ToDoContext>();
            serviceCollection.AddScoped<ITodoService, ToDoService>();
        }
    }
}
