using AutoMapper;
using Iris.Application.ToDo.Dtos;
using Iris.Domain.Services;
using MediatR;

namespace Iris.Application.ToDo.Commands;

public record CreateToDoCommand(string Title,string Description, bool IsCompleted): IRequest<ToDoDto>;

public class CreateToDoHandler(ToDoService _service, IMapper _mapper) : IRequestHandler<CreateToDoCommand, ToDoDto>
{
    public async Task<ToDoDto> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _service.Add(new Domain.Entities.ToDo { Title= request.Title, Description= request.Description,IsCompleted= request.IsCompleted});
        return _mapper.Map<ToDoDto>(entity);
    }
}
