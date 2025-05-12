using Microsoft.EntityFrameworkCore;
using PGTech_io.Models;

namespace PGTech_io.Repository;

public class SectorRepository
{
    private readonly Context _context;
    
    public SectorRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<Subsector>> GetSubsectorsBySectorId(int sectorId)
    {
        try
        {
            var result = await _context.Subsectors.Where(x => x.Idsector == sectorId).ToListAsync();
            
            if (result.Count == 0) { Console.WriteLine("No sectors found"); }
            
            return result;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
}