using AutoMapper;
using Iris.Application.ToDo.Dtos;
using Iris.Domain.Services;
using MediatR;

namespace Iris.Application.ToDo.Queries;

public record GetAllToDoQuery() : IRequest<List<ToDoDto>>;

public class GetAllToDoHandler(ToDoService _service, IMapper _mapper) : IRequestHandler<GetAllToDoQuery, List<ToDoDto>>
{
    public async Task<List<ToDoDto>> Handle(GetAllToDoQuery request, CancellationToken cancellationToken)
    {
        var entities = await _service.GetAll();
        return _mapper.Map<List<ToDoDto>>(entities);
    }
}
