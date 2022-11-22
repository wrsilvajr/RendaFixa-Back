using System;

namespace RendaFixa.Domain
{
    public static class IR
    {
        public static double Taxa(int qtdMes)
        {
            if (qtdMes <= 0)
                throw new ArgumentOutOfRangeException(nameof(qtdMes), "Mês deve ser superior a zero");


            if (qtdMes <= 6)
                return 22.5;

            if (qtdMes <= 12)
                return 20.0;

            if (qtdMes <= 24)
                return 17.5;

            return 15.0;
        }
    }
}
