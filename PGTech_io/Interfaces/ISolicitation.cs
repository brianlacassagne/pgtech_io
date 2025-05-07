using PGTech_io.Models;

namespace PGTech_io.Interfaces;

public interface ISolicitation
{
    public Task<bool> Create(Solicitation solicitation);
    public Task<Solicitation?> Get(int id);
    public Task<List<Solicitation?>> GetAll();
    public Task<bool> Update(Solicitation documentation, int id);
    public Task<bool> Delete(Solicitation solicitation);
}