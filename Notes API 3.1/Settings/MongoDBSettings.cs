namespace Notes_API_3._1.Settings
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string NoteCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string OwnerCollectionName { get; set; }
    }
}
