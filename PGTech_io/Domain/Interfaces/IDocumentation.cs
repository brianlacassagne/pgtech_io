using PGTech_io.Models;

namespace PGTech_io.Interfaces;

public interface IDocumentation
{
    public Task<bool> Create(Documentation documentation);
    public Task<bool> Delete(Documentation documentation);
}