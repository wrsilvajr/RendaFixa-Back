namespace RendaFixa.Domain
{
    public class CDB : TipoRendaFixa
    {
        public CDB(double valorInicial, int prazo)
        {
            ValorInicial = valorInicial;
            Prazo = prazo;
            PossuiIR = true;
        }
        public double ValorInicial { get; set; }
        public double ValorBruto { get; set; }
        public double ValorLiquido { get; set; }
        public int Prazo { get; set; }
        public double CDI { get; } = 0.9;
    }
}
