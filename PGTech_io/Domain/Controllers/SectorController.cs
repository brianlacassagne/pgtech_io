using Microsoft.EntityFrameworkCore;
using PGTech_io.Interfaces;
using PGTech_io.Models;
using PGTech_io.Repository;

namespace PGTech_io.Controllers;

public class SectorController
{
    private readonly ISector _sectorRepository;
    
    public SectorController(ISector sectorRepository)
    {
        _sectorRepository = sectorRepository;
    }

    public async Task<Sector> CreateAsync(Sector sector)
    {
        throw new NotImplementedException();
    }

    public async Task<Sector> UpdateAsync(Sector sector)
    {
        throw new NotImplementedException();
    }

    public async Task<Sector> DeleteAsync(Sector sector)
    {
        throw new NotImplementedException();
    }

    public async Task<Sector> Get(int id)
    {
        var sector = await _sectorRepository.Get(id);
        return sector;
    }
    
    public async Task<List<Sector>> GetAllSectors()
    {
        var sectors = await _sectorRepository.GetAllSectors();
        return sectors;
    }
    
    public async Task<Subsector> GetSubsectorById(int id)
    {
        var subsector = await _sectorRepository.GetSubsectorById(id);
        return subsector;
    }

    public async Task<List<Subsector>> GetSubsectorsById(int subsectorId)
    {
        var subsector = await _sectorRepository.GetSubsectorsBySectorId(subsectorId);
        return subsector;
    }
}