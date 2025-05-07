using Google.Cloud.Firestore;
using PGTech_io.Components.Constants;
using PGTech_io.Interfaces;
using PGTech_io.Models;
using PGTech_io.Service;

namespace PGTech_io.Repository;

public class DocumentationRepository : IDocumentation
{
    private readonly FirestoreService _firestore;
    private readonly CollectionReference _collRef;

    public DocumentationRepository(FirestoreService firestore)
    {
        _firestore = firestore;
        _collRef = _firestore.Db.Collection(DocumentationConstants.TableName);
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

    public async Task<bool> Create(Documentation documentation)
    {
        try
        {
            var latestId = await GetLatestId();
            documentation.IdProperty = latestId;
            await _collRef.AddAsync(documentation);
            Console.WriteLine($"Entity: {nameof(Documentation)} created successfully! Id: {latestId}");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Documentation>> GetAllByInteractionId(int interactionId)
    {
        try
        {
            var result = _collRef.WhereEqualTo("interactionId", interactionId).GetSnapshotAsync().Result;
            if (result.Count > 0)
            {
                Console.WriteLine($"Documentation list count: {result.Count > 0}");
                return Task.FromResult(result.Select(x => x.ConvertTo<Documentation>()).ToList());
            }
            return Task.FromResult(new List<Documentation>());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Update(Documentation documentation, int id)
    {
        bool returnValue = false;
        
        try
        {
            var docRef = _collRef.Document(documentation.IdProperty.ToString());
            var result = await docRef.GetSnapshotAsync();

            if (result != null)
            {
                Console.WriteLine("Document found!");
                await docRef.SetAsync(documentation);
                returnValue = true;
            }
            
            if (returnValue) { Console.WriteLine("Document updated"); }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return returnValue;
    }

    public async Task<bool> Delete(Documentation documentation)
    {
        bool returnValue = false;
        
        try
        {
            var docRef = _collRef.Document(documentation.IdProperty.ToString());
            var result = await docRef.GetSnapshotAsync();
            

            if (result != null)
            {
                Console.WriteLine("Documentation found");
                await docRef.DeleteAsync();
                returnValue = true;
            }
            
            if (returnValue) { Console.WriteLine("Document deleteed"); }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return returnValue;
    }
}