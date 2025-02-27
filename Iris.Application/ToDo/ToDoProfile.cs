using AutoMapper;
using Iris.Application.ToDo.Dtos;

namespace Iris.Application.ToDo;

public class ToDoProfile:Profile
{
    public ToDoProfile()
    {
        CreateMap<Domain.Entities.ToDo, ToDoDto>().ReverseMap();
    }
}
