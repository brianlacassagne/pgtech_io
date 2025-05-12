using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;
using PGTech_io.Components.Constants;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Repository;

public class ResponseRepository : IResponse
{
    private readonly Context _db;

    public ResponseRepository(Context context)
    {
        _db = context;
    }

    public async Task<bool> Create(Response response)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
            
        try
        {
            _db.Add(response);

            var saved = await _db.SaveChangesAsync() > 0;

            Console.WriteLine(!saved
                ? "Response created"
                : "Response not created");
            
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

    public async Task<Response?> Get(int id)
    {
        try
        {
            var result = _db.Responses.FirstOrDefault(x => x.Id == id); //Preferable
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return null;
    }
    
    public async Task<Response?> GetBySolicitationId(int id)
    {
        try
        {
            var result = _db.Responses.FirstOrDefault(x => x.Idsender == id);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Response?>> GetAll() //
    {
        try
        {
            var result = _db.Responses.ToList();
            
            if (result.Count == 0)
                Console.WriteLine("Attention: Response List is empty");

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<string> ObtainIfSenderAnswered(int senderId)
    {
        string return1 = "";
        try
        {
            var found = _db.Responses.FirstOrDefaultAsync(x => x.Idsender == senderId);
            
            Console.WriteLine(found);
            
            if (await found != null)
                return1 = "Contestado";
            
            return return1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Update(Response response, int id)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
            var existingResponse = await _db.Responses.FindAsync(id);

            existingResponse.Solutiondescription = response.Solutiondescription;
            existingResponse.Updatedwhen = response.Updatedwhen;
            
            _db.Update(existingResponse);
            
            var saved = await _db.SaveChangesAsync() > 0;
            
            Console.WriteLine(!saved
            ? "Response was updated"
            : "Response not updated");

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

    public async Task<bool> Delete(Response response)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();

        try
        {
            _db.Remove(response);
            
            var saved = await _db.SaveChangesAsync() > 0;
            
            Console.WriteLine(!saved
            ? "Response was deleted"
            : "Response not deleted");
            
            await transaction.CommitAsync();
            
            return saved;
        }
        catch (Exception e)
        {
            transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }
}