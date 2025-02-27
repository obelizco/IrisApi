using Iris.Domain.Entities;
using Iris.Domain.Exceptions;
using Iris.Domain.Ports;

namespace Iris.Domain.Services;

public class ToDoService(IToDoRepository _toDoRepository)
{
    public async Task<List<ToDo>> GetAll() => await _toDoRepository.GetAll();

    public async Task<ToDo> Add(ToDo todo) => await _toDoRepository.Add(todo);

    public  async Task<ToDo> Update(ToDo todo){
        var entity = await GetById(todo.Id);
        if (entity!=null)
        {
            entity.Title = todo.Title;
            entity.Description = todo.Description;
            entity.IsCompleted = todo.IsCompleted;
            await _toDoRepository.Update(entity);
        }
        else
        {
            throw new AppException($"No se encontro ToDo con id: {todo.Id}");
        }
            return entity;
    }

    public async Task Delete(int Id)
    {
        var entity = await GetById(Id);
        if (entity != null)
        {
            await _toDoRepository.Delete(entity);
        }
    }

    public async Task<ToDo?> GetById(int id) => await _toDoRepository.GetById(id);
}
