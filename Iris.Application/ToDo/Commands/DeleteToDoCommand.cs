
using Iris.Domain.Services;
using MediatR;

namespace Iris.Application.ToDo.Commands;

public record DeleteToDoCommand(int Id):IRequest;
public class DeleteToDoHandler(ToDoService _service) : IRequestHandler<DeleteToDoCommand>
{
    public async Task Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
    {
        await _service.Delete(request.Id);
    }
}
