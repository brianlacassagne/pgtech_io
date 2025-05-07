using PGTech_io.Models;

namespace PGTech_io.Interfaces;

public interface IDocumentation
{
    public Task<bool> Create(Documentation documentation);
    public Task<List<Documentation>> GetAllByInteractionId(int interactionId);
    public Task<bool> Update(Documentation documentation, int id);
    public Task<bool> Delete(Documentation documentation);
}