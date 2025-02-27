using AutoMapper;
using Iris.Application.ToDo.Dtos;
using Iris.Domain.Services;
using MediatR;


namespace Iris.Application.ToDo.Commands;

public record UpdateToDoCommand(int Id,string Title, string Description, bool IsCompleted) : IRequest<ToDoDto>;

public class UpdateToDoHandler(ToDoService _service, IMapper _mapper) : IRequestHandler<UpdateToDoCommand, ToDoDto>
{
    public async Task<ToDoDto> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _service.Update(new Domain.Entities.ToDo { 
            Id = request.Id, 
            Title = request.Title, 
            Description = request.Description, 
            IsCompleted = request.IsCompleted
        });
        return _mapper.Map<ToDoDto>(entity);
    }
}

