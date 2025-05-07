using Microsoft.AspNetCore.Mvc;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DocumentationController : ControllerBase
{
    private readonly IDocumentation repository;
    
    public DocumentationController(IDocumentation _repository)
    {
        repository = _repository;
    }

    [HttpPost]
    public async Task<bool> Post([FromBody] Documentation documentation)
    {
        var result = await repository.Create(documentation);
        return result;
    }

    [HttpGet("id/{id:int}")]
    public async Task<List<Documentation>> GetAllByInteractionId([FromRoute] int id)
    {
        var result = await repository.GetAllByInteractionId(id);
        return result;
    }

    [HttpPut("id/{id:int}")]
    public async Task<bool> Put([FromBody] Documentation documentation, [FromRoute] int id)
    {
        var result = await repository.Update(documentation, id);
        return result;
    }

    [HttpDelete("id/{id:int}")]
    public async Task<bool> Delete([FromBody] Documentation documentation)
    {
        var result = await repository.Delete(documentation);
        return result;
    }
}