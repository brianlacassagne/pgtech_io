using Google.Cloud.Firestore;
using PGTech_io.Components.Constants;
using PGTech_io.Interfaces;
using PGTech_io.Models;
using PGTech_io.Service;

namespace PGTech_io.Repository;

public class ResponseRepository : IResponse
{
    private readonly FirestoreService _firestore;
    private readonly CollectionReference _collRef;

    public ResponseRepository(FirestoreService firestore)
    {
        _firestore = firestore;
        _collRef = _firestore.Db.Collection(ResponseConstants.TableName);
    }
    
    private async Task<int> GetLatestId() // Again, Firebase does not allow auto incrementation
    {
        int latestId = 1;
        
        try
        {
            var query = _collRef.OrderByDescending("Id").Limit(1);
            var result = await query.GetSnapshotAsync();

            if (result.Documents.Count > 0)
            {
                var docRef = result.Documents[0];
                latestId = Convert.ToInt32(docRef.GetValue<int>("Id"));
                return ++latestId;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return latestId;
    }

    public async Task<bool> Create(Response response)
    {
        try
        {
            var latestId = await GetLatestId();
            response.IdProperty = latestId;
            await _collRef.AddAsync(response);
            Console.WriteLine($"Entity: {nameof(Response)} created successfully! Id: {latestId}");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response?> Get(int id)
    {
        try
        {
            var result = await _collRef.GetSnapshotAsync();

            foreach (var document in result)
            {
                if (document.GetValue<int>("Id") == id)
                {
                    return document.ConvertTo<Response>();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return null;
    }

    public async Task<List<Response?>> GetAll()
    {
        List<Response?> responses = new();
        
        try
        {
            var snapshot = await _collRef.GetSnapshotAsync();

            foreach (var document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    var docRef = document.ConvertTo<Response>();
                    responses.Add(docRef);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return responses;

    }

    public async Task<bool> Update(Response response, int id)
    {
        bool returnValue = false;
        
        try
        {
            var docRef = _collRef.Document(response.IdProperty.ToString());
            var result = await docRef.GetSnapshotAsync();

            if (result != null)
            {
                Console.WriteLine("Response found");
                response.UpdatedWhenProperty = DateTime.UtcNow;
                await docRef.SetAsync(response);
                returnValue = true;
            }
            
            if (returnValue) { Console.WriteLine("Response updated"); }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return returnValue;
    }

    public async Task<bool> Delete(Response response)
    {
        bool returnValue = false;

        try
        {
            var docRef = _collRef.Document(response.IdProperty.ToString());
            var result = await docRef.GetSnapshotAsync();

            if (result != null)
            {
                Console.WriteLine("Response found");
                await docRef.DeleteAsync();
                returnValue = true;
            }
            
            if (returnValue) { Console.WriteLine("Response deleted"); }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return returnValue;
    }
}