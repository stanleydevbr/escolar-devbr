using DevBr.Core.eSocial.Enumeradores;
using DevBr.Core.eSocial.Eventos.S1005;
using DevBr.Core.eSocial.Events;
using System.Xml;

namespace DevBr.Core.Tests
{
    public class eSocialHelperTest
    {

        public static void ValidarEnumeradorTest()
        {
            Console.WriteLine(TipoAmbiente.ToValores());
        }
        public static void CreateLinqXmlTest()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            root.SetAttribute("name", "value");
            XmlElement child = doc.CreateElement("child");
            child.InnerText = "text node";
            root.AppendChild(child);
            doc.AppendChild(root);
            Console.WriteLine(doc.OuterXml);
        }

        public static void CreateIdeEmpregadorText()
        {
            var emp = new InfoEmpregador
            {
                Inclusao = new Inclusao
                {
                    IdePeriodo = new IdePeriodo { IniValid = DateTime.Now },
                    InfoCadastro = new InfoCadastro
                    {
                        NmRazao = "Empresa XYZ",
                        ClassTrib = 1,
                        IndConstr = 2,
                        IndCoop = 3,
                        IndDesFolha = 4,
                        IndEntEd = "sdfa",
                        IndOptRegEletron = 1,
                        Contato = new Contato()
                        {
                            CpfCtt = "teste",
                            Email = "teste@gmail.com",
                            FoneFixo = "0909090909",
                            NmCtt = "dkfjdkfj"
                        },
                        SoftwareHouse = new SoftwareHouse()
                        {
                            CnpjSoftHouse = "8158058445",
                            Email = "empresa@gmail.com",
                            NmCont = "SoftwareHouse Ltda",
                            NmRazao = "DevBr Ltda.",
                            Telefone = "545655456"
                        },
                    }
                }
            };
            emp.Inclusao.InfoCadastro.AddInfoComplementar(12);
            emp.Inclusao.InfoCadastro.AddInfoComplementar(13);
            emp.Inclusao.InfoCadastro.AddInfoComplementar(14);

            var infoEmp = new EvtInfoEmpregador(1, 2, 35, "EvtInfoEmpregador", "02_02_02");
            infoEmp.InfoEmpregador = emp;
            infoEmp.IdeEmpregador = new IdeEmpregador { NrInsc = "01552565000144", TpInsc = 1 };

            Console.WriteLine(infoEmp.GetXmlDocument());

            //Console.WriteLine(Guid.NewGuid().ToString("N").ToUpper());
            //Console.WriteLine(Guid.NewGuid().ToString("D"));
            //Console.WriteLine(Guid.NewGuid().ToString("B"));
            //Console.WriteLine(Guid.NewGuid().ToString("P"));
            //Console.WriteLine(Guid.NewGuid().ToString("X"));

            //XNamespace ns = XNamespace.Get(@"http://www.esocial.gov.br/schema/evt/evtInfoEmpregador/v02_02_02");

            //XDocument doc = new XDocument(
            //    new XDeclaration("1.0", "UTF-8", "no"),
            //    new XElement(ns + "eSocial",
            //        new XAttribute("xmlns", ns),
            //            new XElement(ns + "evtInfoEmpregador",
            //            new XAttribute("ID", Guid.NewGuid()),
            //            emp.GetXmlElements(ns))));
            //Console.WriteLine(doc);

            //XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", "no"));
            //var root = new XElement(ns + "eSocial");
            //root.Add(info.GetXmlElements());
            //doc.Add(root);
            //Console.WriteLine(doc);

            //XElement doc = new XElement(ns + "eSocial",
            //    new XAttribute("xmlns", @"http://www.esocial.gov.br/schema/evt/evtInfoEmpregador/v02_02_02"),
            //    new XElement(ns + "evento",
            //    new XAttribute("ID", Guid.NewGuid()),
            //    info.GetXmlElements(ns)
            //    ));

            //Console.WriteLine(doc);

            //XNamespace ci = "http://somewhere.com";
            //XNamespace ca = "http://somewhereelse.com";

            //XElement element = new XElement("root",
            //    new XAttribute(XNamespace.Xmlns + "ci", ci),
            //    new XAttribute(XNamespace.Xmlns + "ca", ca),
            //        new XElement(ci + "field1", "test"),
            //        new XElement(ca + "field2", "another test"));
            //Console.WriteLine(element);

            //var result = new XDocument(
            //    new XElement(ns + "rootNode",
            //        new XElement(ns + "child",
            //            //new XText("Hello World!")
            //            info.GetXmlElements(ns)
            //         )
            //     )
            // );
            //Console.WriteLine(result);

            //XNamespace aw = "http://www.adventure-works.com";
            //XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            //XElement root = new XElement(aw + "Root",
            //    new XAttribute("xmlns", "http://www.adventure-works.com"),
            //    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            //    new XAttribute(xsi + "SchemaLocation", "http://www.SomeLocatation.Com/MySchemaDoc.xsd"),

            //    new XElement(aw + "Book",
            //      new XAttribute(aw + "title", "Enders Game"),
            //      new XAttribute(aw + "author", "Orson Scott Card")),
            //    new XElement(aw + "Book",
            //      new XAttribute(aw + "title", "I Robot"),
            //      new XAttribute(aw + "author", "Isaac Asimov")));

            //Console.WriteLine(root);
        }

        public static void S1005_InclusaoEstabelecimentoTest()
        {
            var estab = new EvtTabEstab(1, 2, 1, "EvtTabEstab", "02_02_02");
            Console.WriteLine(estab.EhValido());
            Console.WriteLine(estab.GetXmlDocument());
        }
    }
}
