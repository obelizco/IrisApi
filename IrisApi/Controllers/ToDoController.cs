using Iris.Application.ToDo.Commands;
using Iris.Application.ToDo.Dtos;
using Iris.Application.ToDo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IrisApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ToDoDto> Create(CreateToDoCommand command) => await _mediator.Send(command);
    
    [HttpPut("{id}")]
    public async Task<ToDoDto> Update(UpdateToDoCommand command) => await _mediator.Send(command);
    
    [HttpGet]
    public async Task<List<ToDoDto>> GetAll() => await _mediator.Send(new GetAllToDoQuery());
   
    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _mediator.Send(new DeleteToDoCommand(id));
    
}
