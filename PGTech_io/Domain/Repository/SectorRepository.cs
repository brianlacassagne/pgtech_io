using Microsoft.EntityFrameworkCore;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Repository;

public class SectorRepository : ISector
{
    private readonly Context _context;
    
    public SectorRepository(Context context)
    {
        _context = context;
    }

    public Task<bool> Create(Sector sector)
    {
        throw new NotImplementedException();
    }

    public async Task<Sector> Get(int sectorId)
    {
        int sectorInt = Convert.ToInt32(sectorId);
        
        try
        {
            var result = await _context.Sectors.FirstOrDefaultAsync(x => x.Id == sectorInt);
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    
    public async Task<List<Sector>> GetAllSectors()
    {
        try
        {
            var result = await _context.Sectors.ToListAsync();
            
            if (result.Count == 0) { Console.WriteLine("No sectors found"); }
            
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public Task<bool> Update(Sector sector)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Subsector>> GetSubsectorsBySectorId(int sectorId)
    {
        try
        {
            var result = await _context.Subsectors.Where(x => x.Idsector == sectorId).ToListAsync();
            return result;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
    
    public async Task<Subsector> GetSubsectorById(int subsectorId)
    {
        try
        {
            var result = await _context.Subsectors.Where(x => x.Id == subsectorId).FirstAsync();
            return result;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
}