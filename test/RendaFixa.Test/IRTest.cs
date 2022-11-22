using System;
using Xunit;

namespace RendaFixa.Test
{
    public class IRTest
    {
        [Theory]
        [Trait("Renda Fixa", "Retorno do IR")]
        [InlineData(-2)]
        [InlineData(0)]
        public void IR_Exception(int qtdMes)
        {
            Assert.Throws<ArgumentOutOfRangeException>("qtdMes", () => Domain.IR.Taxa(qtdMes));
        }

        [Theory]
        [Trait("Renda Fixa", "Retorno do IR")]
        [InlineData(1, 22.5)]
        [InlineData(6, 22.5)]
        [InlineData(7, 20.0)]
        [InlineData(12, 20.0)]
        [InlineData(13, 17.5)]
        [InlineData(24, 17.5)]
        [InlineData(25, 15.0)]
        public void IR_Deve_Retornar_A_Taxa(int qtdMes, double taxaEsperada)
        {
            var taxa = Domain.IR.Taxa(qtdMes);

            Assert.Equal(taxaEsperada, taxa);
        }
    }
}
