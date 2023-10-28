namespace DevBr.Core.Mongo.Configuration
{
    public interface IMongoCoreSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }

    }
}
