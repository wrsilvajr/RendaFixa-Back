using RendaFixa.Domain;
using System;

namespace RendaFixa.Service
{
    public class CDBService : ICDB
    {

        public CDB Calcular(CDB cdb)
        {
            if (cdb.Prazo <= 0)
                throw new ArgumentOutOfRangeException(nameof(cdb), "Prazo deve ser superior a zero");

            cdb = CalcularValorBruto(cdb);

            if (cdb.PossuiIR)
                cdb = CalcularImposto(cdb);

            return cdb;
        }

        private CDB CalcularValorBruto(CDB cdb)
        {

            if (cdb.Prazo == 1)
                cdb.ValorBruto = cdb.ValorInicial * (1 + ((cdb.CDI / 100) * (cdb.TB / 100)));
            else
            {
                double vb = 0;
                for (int i = 0; i < cdb.Prazo; i++)
                {
                    if (i == 0)
                        cdb.ValorBruto = cdb.ValorInicial * (1 + ((cdb.CDI / 100) * (cdb.TB / 100)));
                    else
                    {
                        vb = cdb.ValorBruto;
                        cdb.ValorBruto = vb * (1 + ((cdb.CDI / 100) * (cdb.TB / 100)));
                    }
                }
            }
            return cdb;
        }

        private CDB CalcularImposto(CDB cdb)
        {
            var taxa = Domain.IR.Taxa(cdb.Prazo);

            cdb.ValorLiquido = cdb.ValorInicial + ((cdb.ValorBruto - cdb.ValorInicial) * (1 - (taxa / 100)));

            return cdb;
        }
    }
}