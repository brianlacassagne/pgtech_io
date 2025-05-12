using PGTech_io.Models;
using PGTech_io.Repository;

namespace PGTech_io.Controllers;

public class SectorController
{
    SectorRepository _sectorRepository;
    
    public SectorController(SectorRepository sectorRepository)
    {
        _sectorRepository = sectorRepository;
    }

    public async Task<List<Subsector>> GetSubsectorsById(int subsectorId)
    {
        var subsector = await _sectorRepository.GetSubsectorsBySectorId(subsectorId);
        return subsector;
    }
}