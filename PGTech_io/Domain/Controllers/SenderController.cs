using Microsoft.AspNetCore.Mvc;
using PGTech_io.DTO;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SenderController : ControllerBase
{
    private readonly ISender repository;
    public SenderController(ISender _repository)
    {
        repository = _repository;
    }

    [HttpPost]
    public async Task<bool> Post([FromBody] SenderDTO sender)
    {
        var result = await repository.Create(sender);
        return result;
    }

    [HttpGet("id/{id:int}")]
    public async Task<SenderDTO?> Get([FromRoute] int id)
    {
        var result = await repository.Get(id);
        return result;
    }
    
    [HttpGet]
    public async Task<List<SenderDTO?>> GetAll()
    {
        var result = await repository.GetAll();
        return result;
    }
    
    [HttpPut("id/{id:int}")]
    public async Task<bool> Put([FromBody] SenderDTO sender, int id)
    {
        var result = await repository.Update(sender, id);
        return result;
    }

    [HttpDelete("id/{id:int}")]
    public async Task<bool> Delete([FromBody] SenderDTO sender)
    {
        var result = await repository.Delete(sender);
        return result;
    }
}