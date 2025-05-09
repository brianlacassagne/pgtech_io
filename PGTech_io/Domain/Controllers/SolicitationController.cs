using Microsoft.AspNetCore.Mvc;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SolicitationController : ControllerBase
{
    private readonly ISolicitation repository;
    public SolicitationController(ISolicitation _repository)
    {
        repository = _repository;
    }

    [HttpPost]
    public async Task<bool> Post([FromBody] Solicit solicitation)
    {
        var result = await repository.Create(solicitation);
        return result;
    }

    [HttpGet("id/{id:int}")]
    public async Task<Solicit?> Get([FromRoute] int id)
    {
        var result = await repository.Get(id);
        return result;
    }
    
    [HttpGet]
    public async Task<List<Solicit?>> GetAll()
    {
        var result = await repository.GetAll();
        return result;
    }


    [HttpPut("id/{id:int}")]
    public async Task<bool> Put([FromBody] Solicit solicitation, int id)
    {
        var result = await repository.Update(solicitation, id);
        return result;
    }

    [HttpDelete("id/{id:int}")]
    public async Task<bool> Delete([FromBody] Solicit solicitation)
    {
        var result = await repository.Delete(solicitation);
        return result;
    }
}