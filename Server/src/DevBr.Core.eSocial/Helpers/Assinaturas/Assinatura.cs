using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Linq;

namespace DevBr.Core.eSocial.Assinaturas
{
    public static class Assinatura
    {
        public static XmlDocument SignXmlDoc(this XmlDocument xmlDoc, X509Certificate2 certificate)
        {
            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = certificate.GetRSAPrivateKey();
            signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA256Url;

            Reference reference = new Reference(string.Empty);
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigC14NTransform());
            reference.DigestMethod = SignedXml.XmlDsigSHA256Url;

            signedXml.AddReference(reference);
            signedXml.KeyInfo = new KeyInfo();
            signedXml.KeyInfo.AddClause(new KeyInfoX509Data(certificate));
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();
            //XDocument
            XDocument document = new XDocument();
            XElement element = new XElement("", signedXml.GetXml());
            element.Add(xmlDoc.ImportNode(xmlDigitalSignature, true));
            document.Add(element);

            xmlDoc?.DocumentElement?.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

            if (xmlDoc?.FirstChild is XmlDeclaration)
                xmlDoc.RemoveChild(xmlDoc.FirstChild);

            return xmlDoc;
        }

        public static XDocument SginXDocument(this XDocument document, X509Certificate2 certificate, XNamespace ns)
        {
            XmlDocument xmlDoc = new XmlDocument();
            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = certificate.GetRSAPrivateKey();
            signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA256Url;

            Reference reference = new Reference(string.Empty);
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigC14NTransform());
            reference.DigestMethod = SignedXml.XmlDsigSHA256Url;

            signedXml.AddReference(reference);
            signedXml.KeyInfo = new KeyInfo();
            signedXml.KeyInfo.AddClause(new KeyInfoX509Data(certificate));
            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();

            XElement element = new XElement(ns + "", signedXml.GetXml());
            element.Add(xmlDoc.ImportNode(xmlDigitalSignature, true));
            document.Add(element);
            return document;
        }
    }
}
