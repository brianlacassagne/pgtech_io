using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;
using PGTech_io.Components.Constants;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Repository;

public class DocumentationRepository : IDocumentation
{
    private readonly Context _db;

    public DocumentationRepository(Context db)
    {
        _db = db;
    }

    public async Task<bool> Create(Documentation documentation)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
            await _db.Documentations.AddAsync(documentation);
            
            var saved = await _db.SaveChangesAsync() > 0;

            Console.WriteLine(!saved
                ? $"Documentation: {documentation.Id} failed to save"
                : $"Documentation: {documentation.Id} saved");

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

    public Task<List<Documentation>> GetAllBySolicitId(int solicitId)
    {
        try
        {
            var documentations = _db.Documentations.Where(x => x.IdSolicitation == solicitId).ToList();
            
            if (documentations.Count == 0)
                Console.WriteLine($"Attention! List of Documents belonging to {solicitId} is empty!");
            
            return Task.FromResult(documentations);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Update(Documentation documentation)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
            _db.Documentations.Update(documentation);
            
            var saved = await _db.SaveChangesAsync() > 0;

            Console.WriteLine(!saved
                ? $"Documentation: {documentation.Id} failed to update"
                : $"Documentation: {documentation.Id} saved");

            return saved;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Delete(Documentation documentation)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
            _db.Documentations.Remove(documentation);
            
            var saved = await _db.SaveChangesAsync() > 0;

            Console.WriteLine(!saved
                ? $"Documentation: {documentation.Id} failed to delete"
                : $"Documentation: {documentation.Id} saved");

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