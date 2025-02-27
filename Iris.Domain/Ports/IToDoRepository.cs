using Iris.Domain.Entities;

namespace Iris.Domain.Ports;

public interface IToDoRepository
{
    public Task<List<ToDo>> GetAll();
    public Task<ToDo> Add(ToDo todo);
    public Task<ToDo> Update(ToDo todo);
    public Task Delete(ToDo todo);
    public Task<ToDo?> GetById(int id);
}
