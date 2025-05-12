using PGTech_io.Models;

namespace PGTech_io.Interfaces;

public interface IResponse
{
    public Task<bool> Create(Response response);
    public Task<Response?> Get(int id);
    public Task<Response?> GetBySolicitationId(int solicitationId);
    public Task<List<Response?>> GetAll();
    public Task<bool> Update(Response response, int id);
    public Task<bool> Delete(Response response);
    public Task<string> ObtainIfSenderAnswered(int senderId);
}