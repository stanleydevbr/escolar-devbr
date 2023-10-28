using DevBr.Core.eSocial.Events;
using System;
using Xunit;

namespace DevBr.eSocial.Tests
{

    public class S1000Test
    {
        [Fact(DisplayName = "Gerar arquivo S-1000 - Informações do Empregador/Contribuinte/Orgão Público")]
        [Trait("Evento de Tabela", "Gerar Evento S-1000")]
        public void Gerar_evento_S1000_Test()
        {
            // Arrange
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

            // Act
            var docx = infoEmp.GetXmlDocument();
            // Assert
            Assert.Equal(true, infoEmp?.EhValido());
        }
    }
}
