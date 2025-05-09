using Microsoft.AspNetCore.Mvc;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ResponseController : ControllerBase
{
    private readonly IResponse repository;
    public ResponseController(IResponse _repository)
    {
        repository = _repository;
    }

    [HttpPost]
    public async Task<bool> Post([FromBody] Response response, int solicitationId)
    {
        response.Idsolicitation = solicitationId;
        var result = await repository.Create(response);
        return result;
    }

    [HttpGet("id/{id:int}")]
    public async Task<Response?> Get([FromRoute] int id)
    {
        var result = await repository.Get(id);
        return result;
    }
    
    [HttpGet]
    public async Task<Response?> GetBySolicitationId(int solicitationId)
    {
        var result = await repository.GetBySolicitationId(solicitationId);
        return result;
    }
    
    [HttpGet]
    public async Task<List<Response?>> GetAll()
    {
        var result = await repository.GetAll();
        return result;
    }

    [HttpPut("id/{id:int}")]
    public async Task<bool> Put([FromBody] Response response, int id)
    {
        var result = await repository.Update(response, id);
        return result;
    }

    [HttpDelete("id/{id:int}")]
    public async Task<bool> Delete([FromBody] Response response)
    {
        var result = await repository.Delete(response);
        return result;
    }
}