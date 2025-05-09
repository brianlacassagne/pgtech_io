using PGTech_io.Models;

namespace PGTech_io.Interfaces;

public interface ISolicitation
{
    public Task<bool> Create(Solicit solicitation);
    public Task<Solicit?> Get(int id);
    public Task<List<Solicit?>> GetAll();
    public Task<bool> Update(Solicit solicitation, int id);
    public Task<bool> Delete(Solicit solicitation);
}