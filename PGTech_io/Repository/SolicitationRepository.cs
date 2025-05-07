using Google.Cloud.Firestore;
using PGTech_io.Components.Constants;
using PGTech_io.Interfaces;
using PGTech_io.Models;
using PGTech_io.Service;

namespace PGTech_io.Repository;

public class SolicitationRepository : ISolicitation
{
    private readonly FirestoreService _firestore;
    private readonly CollectionReference _collRef;

    public SolicitationRepository(FirestoreService firestore)
    {
        _firestore = firestore;
        _collRef = _firestore.Db.Collection(SolicitationConstants.TableName);
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

    public async Task<bool> Create(Solicitation solicitation)
    {
        try
        {
            var latestId = await GetLatestId();
            solicitation.IdProperty = latestId;
            await _collRef.AddAsync(solicitation);
            Console.WriteLine($"Entity: {nameof(Solicitation)} created successfully! Id: {latestId}");
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Solicitation?> Get(int id)
    {
        try
        {
            //var query = _collRefInteraction.WhereEqualTo("IdInteraction", interactionId);
            //var result = await query.GetSnapshotAsync();

            var result = await _collRef.GetSnapshotAsync();

            foreach (var document in result)
            {
                if (document.GetValue<int>("Id") == id)
                {
                    return document.ConvertTo<Solicitation>();
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

    public async Task<List<Solicitation?>> GetAll()
    {
        List<Solicitation?> solicitations = new();
        
        try
        {
            var snapshot = await _collRef.GetSnapshotAsync();

            foreach (var document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    var docRef = document.ConvertTo<Solicitation>();
                    solicitations.Add(docRef);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return solicitations;
    }

    public async Task<bool> Update(Solicitation solicitation, int id)
    {
        bool returnValue = false;
        
        try
        {
            var docRef = _collRef.Document(solicitation.IdProperty.ToString());
            var result = await docRef.GetSnapshotAsync();

            if (result != null)
            {
                Console.WriteLine("Solicitation found");
                solicitation.UpdatedWhenProperty = DateTime.UtcNow;
                await docRef.SetAsync(solicitation);
                returnValue = true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return returnValue;
    }

    public async Task<bool> Delete(Solicitation solicitation)
    {
        bool returnValue = false;

        try
        {
            var docRef = _collRef.Document(solicitation.IdProperty.ToString());
            var result = await docRef.GetSnapshotAsync();

            if (result != null)
            {
                await docRef.DeleteAsync();
                returnValue = true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return returnValue;
    }
}