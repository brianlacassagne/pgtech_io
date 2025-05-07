using PGTech_io.Models;

namespace PGTech_io.Interfaces;

public interface IResponse
{
    public Task<bool> Create(Response response);
    public Task<Response?> Get(int interactionId);
    public Task<List<Response?>> GetAll();
    public Task<bool> Update(Response documentation, int id);
    public Task<bool> Delete(Response response);
}