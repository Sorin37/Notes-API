namespace Notes_API_3._1.Settings
{
    public interface IMongoDBSettings
    {
        string NoteCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string OwnerCollectionName { get; set; }
    }
}
