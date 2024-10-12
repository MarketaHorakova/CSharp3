using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.WebApi;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {

    }

    [HttpGet]
    public IActionResult Read()
    {

    }
    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId)
    {

    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        return Ok;
    }

    [HttpDelete]
    public IActionResult DeleteById(int toDoItemId)
    {
        return Ok;

    }


}
