using DevBr.Core.eSocial.Eventos.S1005;
using DevBr.Core.eSocial.Events;
using System;
using System.Collections.Generic;
using Xunit;

namespace DevBr.eSocial.Tests
{
    public class S1005Test
    {

        [Fact(DisplayName = "Mudar para uma descrição do metodo")]
        [Trait("Categoria", "Descrição")]
        public void Mudar_Nome_Metodo_Test()
        {
            //Arrange
            var infoEstab = new InfoEstab();
            var estab = new EvtTabEstab(1, 15, 1, "S1005", "02_02_02")
            {
                IndRetif = null,
                PerApur = null,
                NrRecArqBase = null,
                IdeEmpregador = new IdeEmpregador { TpInsc = 1, NrInsc = "01552565000144" },
                InfoEstab = new InfoEstab
                {
                    Inclusao = new InclusaoTabEstab
                    {
                        IdeEstab = new IdeEstab { TpInsc = 1, NrInsc = "01552565000144", IniValid = DateTime.Now },
                        DadosEstab = new DadosEstab
                        {
                            CnaePrep = 45646,
                            CnpjResp = "456",
                            InfoTrab = new InfoTrab
                            {
                                InfoApr = new InfoApr
                                {
                                    NrProcJud = "14525",
                                    InfoEntEduc = new List<InfoEntEduc>()
                                }
                            },
                        }
                    }
                }
            };
        }
    }
    //Act

    //Assert
}





