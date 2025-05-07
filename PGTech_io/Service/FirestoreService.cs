using Google.Cloud.Firestore;

namespace PGTech_io.Service;

public class FirestoreService
{
    private readonly string projectId = "pgtech-io";


    public FirestoreService(IConfiguration configuration)
    {
        var credentialsPath = Path.Combine("/home/brian/Keys", "pgtech-io-firebase-adminsdk-fbsvc-be234acbea.json");
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsPath);
        Db = FirestoreDb.Create(projectId);
    }

    public FirestoreDb Db { get; }
}