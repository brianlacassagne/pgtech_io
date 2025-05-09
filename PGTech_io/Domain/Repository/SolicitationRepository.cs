using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;
using PGTech_io.Components.Constants;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Repository;

public class SolicitationRepository : ISolicitation
{
    private readonly Context _db;

    public SolicitationRepository(Context context)
    {
        _db = context;
    }

    public async Task<bool> Create(Solicit solicitation)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
            Console.WriteLine($"HERE {solicitation.Client}");
            await _db.Solicits.AddAsync(solicitation);
            
            var saved = await _db.SaveChangesAsync() > 0;
            
            Console.WriteLine(!saved
            ? "Solicitation could not be saved."
            : $"Solicitation saved.");
            
            await transaction.CommitAsync();

            return saved;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Solicit?> Get(int id)
    {
        try
        {
            var result = _db.Solicits.FirstOrDefault(x => x.Id == id);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Solicit?>> GetAll()
    {
        try
        {
            var result = _db.Solicits.ToList();
            
            if (result.Count == 0)
                Console.WriteLine("No solicitations were found.");
            
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Update(Solicit solicitation, int id)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
            var exitingSolicitation = await _db.Solicits.FindAsync(id);
            
            exitingSolicitation.Client = solicitation.Client;
            exitingSolicitation.Sector = solicitation.Sector;
            exitingSolicitation.Subsector = solicitation.Subsector;
            exitingSolicitation.Problemdescription = solicitation.Problemdescription;
            exitingSolicitation.Updatedwhen = solicitation.Updatedwhen;
            
            _db.Solicits.Update(exitingSolicitation);
            
            var saved = await _db.SaveChangesAsync() > 0;
            
            Console.WriteLine(!saved
            ? "Solicitation could not be saved."
            : $"Solicitation saved.");
            
            await transaction.CommitAsync();

            return saved;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Delete(Solicit solicitation)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
           _db.Solicits.Remove(solicitation);
           
           var saved = await _db.SaveChangesAsync() > 0;
           
           Console.WriteLine(!saved
           ? "Solicitation could not be saved."
           : $"Solicitation saved.");

           await transaction.CommitAsync();
           
           return saved;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }
}