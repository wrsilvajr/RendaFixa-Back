using RendaFixa.Domain;
using RendaFixa.Service;
using System;
using Xunit;

namespace RendaFixa.Test
{
    public class CDBServiceTest
    {
        [Theory]
        [Trait("Renda Fixa - CDB", "Retorna o calculo do cdb")]
        [InlineData(1000, -2)]
        [InlineData(1000, 0)]
        public void CDB_Exception(double valorInicial, int prazo)
        {
            CDB cdb = new CDB(valorInicial, prazo);

            ICDB cdbService = new CDBService();

            Assert.Throws<ArgumentOutOfRangeException>(nameof(cdb), () => cdbService.Calcular(cdb));
        }

        [Theory]
        [Trait("Renda Fixa - CDB", "Retorna o calculo do cdb")]
        [InlineData(1000, 1, 1007.53)]
        [InlineData(1000, 6, 1046.31)]
        [InlineData(1000, 7, 1056.05)]
        [InlineData(1000, 12, 1098.47)]
        [InlineData(1000, 13, 1110.55)]
        [InlineData(1000, 24, 1215.58)]
        [InlineData(1000, 25, 1232.54)]
        public void Deve_Retornar_CDB_Com_ValorBruto_E_Liquido(double valorInicial, int prazo, double valorLiquidoEsperado)
        {
            CDB cdb = new CDB(valorInicial, prazo);

            ICDB cdbService = new CDBService();

            cdbService.Calcular(cdb);

            Assert.Equal(valorLiquidoEsperado, Math.Round(cdb.ValorLiquido, 2));
        }
    }
}
