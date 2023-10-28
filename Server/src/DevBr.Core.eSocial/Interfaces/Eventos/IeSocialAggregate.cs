using System.Xml.Linq;

namespace DevBr.Core.eSocial.Interfaces.Roots
{
    public interface IeSocialAggregate : IDisposable
    {
        XDocument GetXmlDocument();
    }
}
