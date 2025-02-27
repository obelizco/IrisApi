using Iris.Domain.Entities;
using Iris.Domain.Ports;
using Iris.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Iris.Infraestructure.Adapters;

public class ToDoRepository(IrisContext _context) : IToDoRepository
{
    public async Task<List<ToDo>> GetAll()
    {
        return await _context.ToDoes.ToListAsync();
    }
    
    public async Task<ToDo> Add(ToDo todo)
    {
        var entity= await _context.ToDoes.AddAsync(todo);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task<ToDo> Update(ToDo todo)
    {
        _context.ToDoes.Update(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task Delete(ToDo todo)
    {
        if (todo != null)
        {
            _context.ToDoes.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ToDo?> GetById(int id)
    {
        return await _context.ToDoes.FindAsync(id);
    }
}
