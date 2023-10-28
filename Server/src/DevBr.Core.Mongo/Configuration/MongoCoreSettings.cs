namespace DevBr.Core.Mongo.Configuration
{
    public class MongoCoreSettings : IMongoCoreSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
