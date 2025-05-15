using PGTech_io.Models;

namespace PGTech_io.Interfaces;

public interface ISector
{
    public Task<bool> Create(Sector sector);
    public Task<Sector> Get(int Id);
    public Task<List<Sector>> GetAllSectors();
    public Task<bool> Update(Sector sector);
    public Task<bool> Delete(int id);
    public Task<List<Subsector>> GetSubsectorsBySectorId(int subsectorId);
    public Task<Subsector> GetSubsectorById(int subsectorId);
}