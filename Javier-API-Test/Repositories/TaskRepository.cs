using Javier_API_Test.Models;
using Javier_API_Test.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Javier_API_Test.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<ToDo> Create(ToDo task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<IEnumerable<ToDo>> Get()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<ToDo> Get(Guid Id)
        {
            return await _context.Tasks.FindAsync(Id);
        }

        public async Task Update(ToDo task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}