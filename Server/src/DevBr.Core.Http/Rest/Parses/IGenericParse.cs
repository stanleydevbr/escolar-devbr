namespace DevBr.Core.Http.Rest.Parses
{
    public interface IGenericParse<T>
    {
        string Serialize();
        T Deserialize();
    }
}
