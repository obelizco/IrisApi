namespace Iris.Application.ToDo.Dtos;

public class ToDoDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}
