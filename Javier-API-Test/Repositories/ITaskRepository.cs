using Javier_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Javier_API_Test.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ToDo>> Get();
        Task<ToDo> Get(int id);
        Task<ToDo> Create(ToDo task);
        Task Update(ToDo task);
        Task Delete(int id);
    }
}
